
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Service
{
   public  interface IServiceRepo : IRepositoryBase<MstService>
   {
        Task<bool> CheckDuplication(DuplicateValidation input);
        Task<MstService> GetUserById(string userId);
        Task<MstService> GetUserByName(string userName);
    }
}
