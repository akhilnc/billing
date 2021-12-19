using billing.Data.DbContexts;
using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Admin.Logger
{
    public class AppLoggerRepo : IAppLoggerRepo
    {
        private readonly BillingAppContext _appContext;

        public AppLoggerRepo(BillingAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<AdminAppLogs> SaveLog(AdminAppLogs input)
        {
            DetachEntitys();
            await _appContext.AdminAppLogs.AddAsync(input);
            await _appContext.SaveChangesAsync();
            DetachEntitys();
            return input;
        }

        private void DetachEntitys()
        {
            foreach (var entry in _appContext.ChangeTracker.Entries().ToArray()) entry.State = EntityState.Detached;
        }
    }
}