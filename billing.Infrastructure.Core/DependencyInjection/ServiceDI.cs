using billing.Service.Authentication;
using billing.Service.Masters.User;
using Microsoft.Extensions.DependencyInjection;

namespace billing.Infrastructure.Core.DependencyInjection
{
    public abstract class ServiceDI
    {
        public static void ConfigureService(IServiceCollection services)
        {
            #region Masters

            services.AddTransient<IUserService, UserService>();

            #endregion

            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}