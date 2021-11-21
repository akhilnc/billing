using billing.Infrastructure.Common.Logger;
using billing.Infrastructure.Common.Utlilities.TokenUserClaims;
using billing.Infrastructure.Security.Cryptography;
using billing.Infrastructure.Security.Hashing;
using billing.Infrastructure.Security.Password;
using billing.Infrastructure.Security.Token;
using Microsoft.Extensions.DependencyInjection;

namespace billing.Infrastructure.Core.DependencyInjection
{
    public static class CommonDI
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddScoped<ICrypto, Crypto>();
            services.AddScoped<IHash, Hash>();
            services.AddScoped<IPassword, Password>();
            services.AddScoped<IToken, Token>();

            services.AddScoped<ITokenUserClaims, TokenUserClaims>();

            services.AddScoped<IAppLogger, AppLogger>();
        }
    }
}