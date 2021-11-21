using Microsoft.Extensions.DependencyInjection;

namespace billing.Infrastructure.Core.DependencyInjection
{
    public static class DependencyInjectionMain
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            CommonDI.ConfigureService(services);
            DataDI.ConfigureService(services);
            ServiceDI.ConfigureService(services);
        }
    }
}