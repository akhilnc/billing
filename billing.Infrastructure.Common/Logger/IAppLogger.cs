using System;
using System.Threading.Tasks;
using billing.Data.Generics.General;

namespace billing.Infrastructure.Common.Logger
{
    public interface IAppLogger
    {
        Task<AppErrorResponse> Error(string message, Exception ex);
        Task<AppErrorResponse> Warning(string message);
        Task<AppErrorResponse> Info(string message);
    }
}