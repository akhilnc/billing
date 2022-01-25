using billing.Data.Repositories.Admin.Logger;
using billing.Data.Repositories.Admin.Token;
using billing.Data.Repositories.Billing.Invoice;
using billing.Data.Repositories.Dashboard;
using billing.Data.Repositories.Masters.Customer;
using billing.Data.Repositories.Masters.Service;
using billing.Data.Repositories.Masters.User;
using Microsoft.Extensions.DependencyInjection;

namespace billing.Infrastructure.Core.DependencyInjection
{
    public abstract class DataDI
    {
        public static void ConfigureService(IServiceCollection services)
        {
            #region Masters

            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<IServiceRepo, ServiceRepo>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();
            services.AddTransient<IInvoiceRepo, InvoiceRepo>();
            services.AddTransient<IDashboardRepo, DashboardRepo>();
            services.AddTransient<ICustomerRepo, CustomerRepo>();




            #endregion

            #region Admin

            services.AddScoped<IAppLoggerRepo, AppLoggerRepo>();
            services.AddTransient<ITokenRepo, TokenRepo>();

            #endregion
        }
    }
}