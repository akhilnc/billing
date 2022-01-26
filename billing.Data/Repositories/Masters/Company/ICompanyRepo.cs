using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Company
{
   public interface ICompanyRepo :IRepositoryBase<CompanySettings>
    {
        Task<bool> CheckDuplication(DuplicateValidation input);
        Task<CompanySettings> GetCompanyByUId(string uid);
        Task<CompanySettings> GetCompanyByName(string CompanyName);
    }
}
