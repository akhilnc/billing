using billing.Invoice.Billing.Invoice;
using billing.Service.Authentication;
using billing.Service.Billing.Invoice;
using billing.Service.Dashboard;
using billing.Service.Masters.Company;
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
            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<ICompanyService, CompanyService>();



            #endregion

            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}