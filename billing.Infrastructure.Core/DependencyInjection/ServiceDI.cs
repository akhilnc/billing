using billing.Service.Authentication;
using billing.Service.Masters.Customer;
using billing.Service.Masters.Service;
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
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<ICustomerService, CustomerService>();


            #endregion

            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}