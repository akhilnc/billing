using billing.Data.DTOs;
using billing.Data.Generics;
using billing.Data.Generics.Enum;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Admin.Token;
using billing.Data.Repositories.Masters.User;
using billing.Data.Resources;
using billing.Data.Resources.ModuleMessages;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Security.Token;
using System;
using System.Threading.Tasks;

namespace billing.Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IToken _token;
        private readonly ITokenRepo _tokeRepo;
        private readonly IAppLogger _logger;
        private readonly IUserRepo _userRepo;

        public AuthenticationService(IToken token, ITokenRepo tokeRepo, IAppLogger logger,IUserRepo userRepo)
        {
            _token = token;
            _tokeRepo = tokeRepo;
            _logger = logger;
            _userRepo = userRepo;
        }


        public async Task<Envelope<LoginResponse>> Login(LoginDTO input)
        {
            try
            {
                MstUser authUserDetails = await _userRepo.GetUserByName(input.UserName);
                if (authUserDetails==null)
                {
                    return new Envelope<LoginResponse>(false, null, CommonMessages.USER_NOT_FOUND);
                }
                var user = new UserBase
                {
                    UserGuid = authUserDetails.UId,
                    RefreshTokenIdentifier = Guid.NewGuid().ToString()
                };

                var tokens = new TokenResponse
                {
                    AccessToken = GenToken(user, TokenType.AccessToken, ExpirationUnit.Hour),
                    RefreshToken = GenToken(user, TokenType.RefreshToken, ExpirationUnit.Day)
                };

                var refreshToken = new AdminUserRefreshToken
                {
                    UId = user.RefreshTokenIdentifier,
                    RefreshToken = tokens.RefreshToken.Token,
                    UserUId = user.UserGuid,
                    RefreshTokenExpiry = tokens.RefreshToken.TokenExpiry
                };
                await _tokeRepo.AddAsync(refreshToken);
                await _tokeRepo.CommitAsync();

                var loginResponse = new LoginResponse
                {
                    Tokens = tokens
                };
                return new Envelope<LoginResponse>(true, loginResponse, AdminMessages.LOGIN_SUCCESS);
            }
            catch (Exception e)
            {
                await _logger.Error("Something went wrong", e);
                return new Envelope<LoginResponse>(false, null, CommonMessages.SOMETHING_WRONG);
            }
        }

        public async Task<Envelope<TokenResponse>> GetNewToken(string refreshToken)
        {
            try
            {
                var user = _token.ValidateAndDecode<UserBase>(refreshToken, TokenType.RefreshToken);
                var userToken = await _tokeRepo.GetByIdAsync(user.UserGuid);
                if (userToken != null)
                {
                    var newTokens = new TokenResponse
                    {
                        AccessToken = GenToken(user, TokenType.AccessToken, ExpirationUnit.Minute),
                        RefreshToken = GenToken(user, TokenType.RefreshToken, ExpirationUnit.Day)
                    };
                    return new Envelope<TokenResponse>(true, newTokens, "");
                }
                else
                {
                    return new Envelope<TokenResponse>(true, null, AdminMessages.SESSION_TIMEOUT);
                }
            }
            catch (Exception e)
            {
                await _logger.Error("Something went wrong", e);
                return new Envelope<TokenResponse>(false, null, CommonMessages.SOMETHING_WRONG);
            }
        }

        #region Token Gen

        public TokenOut GenToken(UserBase user, TokenType type, ExpirationUnit unit)
        {
            var tokenSettings = new AppTokenSettings<UserBase>
            {
                Type = TokenType.AccessToken,
                Data = new UserBase
                {
                    UserGuid = user.UserGuid
                },
                ExpUnit = unit
            };
            return _token.GenerateToken(tokenSettings);
        }
        #endregion
    }
}