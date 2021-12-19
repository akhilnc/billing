using System.Threading.Tasks;
using billing.Infrastructure.Common.HttpContext;
using billing.Service.Masters.User;
using Microsoft.AspNetCore.Http;

namespace billing.Infrastructure.Core.Middlewares
{
    /// <summary>
    /// This middleware is invoked before the authorization middleware.
    /// This middleware will extract the user id from the request and
    /// check whether that user is active or whether the user exists in
    /// the system. If the user is not found or inactive then an exception
    /// is thrown.
    /// </summary>
    public class UserStatusCheckMiddleware
    {
        private readonly RequestDelegate _next;

        public UserStatusCheckMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(
            HttpContext context,
            IRequestContext requestContext,
            IUserService userService)
        {
            // Get the user id from the request
            var userId = requestContext.GetUserId();
            var userRole = requestContext.GetUserRole();

            if (!string.IsNullOrEmpty(userId))
            {
                // check the status of the user
                var isUserActive = await userService.IsUserActive(userId, userRole);

                // if the user is inactive then throw an exception
                if (!isUserActive.Item1)
                {
                    //await _logger.Error("Something went wrong", e);
                    //return new Envelope<LoginResponse>(false, null, CommonMessages.SOMETHING_WRONG);
                    //throw new (isUserActive.Item2, isUserActive.Item3);
                }
            }

            // else continue executing the request pipeline
            await _next.Invoke(context).ConfigureAwait(false);
        }
    }
}