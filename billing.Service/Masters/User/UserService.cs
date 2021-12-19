using AutoMapper;
using billing.Data;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Masters.User;
using billing.Data.Resources;
using billing.Data.Resources.Labels;
using billing.Data.Resources.Validations;
using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using billing.Infrastructure.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.User
{
    public class UserService:IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _repo;
        private readonly UserBase _user;
        private readonly IAppLogger _logger;
        private readonly IHash _hash;

        public UserService(IUserRepo repo, IMapper mapper, ITokenUserClaims claims, IAppLogger logger, IHash hash)
        {
            _user = claims.GetClaims();
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
            _hash = hash;
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<MstUser>, IEnumerable<UserDTO>>(await _repo.GetAllAsync());
        }

        public async Task<UserDTO> GetById(string uId)
        {
            return _mapper.Map<MstUser, UserDTO>(await _repo.GetByIdAsync(uId));
        }

        public async Task<Envelope> Save(UserDTO input)
        {
            try
            {
                var mappedInput = _mapper.Map<UserDTO, MstUser>(input);
                string hash; string salt;
                _hash.CreatePasswordHash(input.Password, out hash, out salt);
                mappedInput.PasswordHash = hash;
                mappedInput.PasswordSalt = salt;
               // mappedInput.CreatedBy = _user.UserGuid;
               // mappedInput.ModifiedBy = _user.UserGuid;  
                await _repo.AddAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope(true, DbMessages.CREATED_SUCCESS)
                    : new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {

                await _logger.Error("Something went wrong", e);
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }

        public async Task<Envelope> Update(UserDTO input)
        {
            try
            {                
                var mappedInput = _mapper.Map<UserDTO, MstUser>(input);
                string hash; string salt;
                _hash.CreatePasswordHash(input.Password, out hash, out salt);
                mappedInput.PasswordHash = hash;
                mappedInput.PasswordSalt = salt;
                mappedInput.ModifiedBy = _user.UserGuid;
                await _repo.AddAsync(mappedInput);
                await _repo.UpdateAsync(mappedInput);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope(true, DbMessages.UPDATED_SUCCESS)
                    : new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }

        public async Task<Envelope> Delete(string uId)
        {
            try
            {
                var item = await _repo.GetByIdAsync(uId);
                _repo.Remove(item);
                var count = await _repo.CommitAsync();
                return count > 0
                    ? new Envelope(true, DbMessages.DELETED_SUCCESS)
                    : new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
            catch (Exception e)
            {
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }

        /// <summary>
        /// Check whether the user is active or not
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<(bool, int, string)> IsUserActive(string userId, string userRole)
        {
            var user = await _repo.GetUserById(userId);

            if (user == null)
            {
                return (false, ApplicationConstants.ForceLogoutCodeForInactiveUser, ApplicationConstants.ForceLogoutDeletedUserMessage);
            }

            if (!user.IsActive)
            {
                return (false, ApplicationConstants.ForceLogoutCodeForInactiveUser, ApplicationConstants.ForceLogoutInactiveUserMessage);
            }

            //var role = GetApplicationRole(user);
            return default;
                /*(role == userRole, ApplicationConstants.ForceLogoutCodeForRoleChangedUser, string.Empty);*/
        }
        #region Validations

        public async Task<Envelope> CheckDuplication(DuplicateValidation input)
        {
            try
            {
                return
                    await _repo.CheckDuplication(input) ?
                    new Envelope(true, CommonValidationMessages.CUSTOM_VALUE_DUPLICATION.Replace("{{Label}}", CommonLabels.ResourceManager.GetString(input.Label)))
                    :
                    new Envelope(false, CommonMessages.NO_DUPLICATION);
            }
            catch (Exception e)
            {
                return new Envelope(false, CommonMessages.SOMETHING_WRONG);
            }
        }
        #endregion
    }
}
