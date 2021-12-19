using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using billing.Data;
using billing.Infrastructure.Common.HttpContext;
using Microsoft.AspNetCore.Http;
using static billing.Data.ApplicationConstants;

namespace billing.Infrastructure.Common.Logger.HttpContextHttpContext
{
    public class RequestContext : IRequestContext
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public RequestContext(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            string bearerToken = GetUserToken();
            try
            {
                if (!string.IsNullOrEmpty(bearerToken))
                {
                    bearerToken = bearerToken.Replace(ApplicationConstants.Bearer, string.Empty);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    if (tokenHandler.ReadToken(bearerToken) is JwtSecurityToken tokenSecure)
                    {
                        return Convert.ToString(tokenSecure.Claims?.First(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value);
                    }
                }
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        public string GetUserRole()
        {
            string bearerToken = GetUserToken();
            try
            {
                if (!string.IsNullOrEmpty(bearerToken))
                {
                    bearerToken = bearerToken.Replace(ApplicationConstants.Bearer, string.Empty);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    if (tokenHandler.ReadToken(bearerToken) is JwtSecurityToken tokenSecure)
                    {
                        return Convert.ToString(tokenSecure.Claims?.First(claim => claim.Type == "roles")?.Value);
                    }
                }
                return null;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private string GetUserToken()
        {
            var requestHeaders = _contextAccessor?.HttpContext?.Request?.Headers;
            if (requestHeaders != null)
            {
                var token = requestHeaders.ToDictionary(l => l.Key.ToLowerInvariant(), k => k.Value).ContainsKey(Headers.Authorization.ToLowerInvariant()) ?
                    requestHeaders.ToDictionary(l => l.Key.ToLowerInvariant(), k => k.Value.ToString())[Headers.Authorization.ToLowerInvariant()] : string.Empty;
                if (!string.IsNullOrEmpty(token))
                {
                    return token.Replace("Bearer ", string.Empty);
                }
            }
            return null;
        }
    }
}