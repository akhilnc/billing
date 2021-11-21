using billing.Data.Repositories.Admin.Logger;
using billing.Data.Repositories.Admin.Token;
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

            #endregion

            #region Admin

            services.AddScoped<IAppLoggerRepo, AppLoggerRepo>();
            services.AddTransient<ITokenRepo, TokenRepo>();

            #endregion
        }
    }
}