using System.Threading.Tasks;
using billing.Data.Models;

namespace billing.Data.Repositories.Admin.Logger
{
    public interface IAppLoggerRepo
    {
        Task<AdminAppLogs> SaveLog(AdminAppLogs input);
    }
}