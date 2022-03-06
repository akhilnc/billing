
using billing.Data.DTOs.Dropdown;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Service
{
   public  interface IServiceRepo : IRepositoryBase<MstService>
   {
        Task<bool> CheckDuplication(DuplicateValidation input);
        Task<MstService> GetServiceByUId(string uid);
        Task<IEnumerable<ServiceDropdownDTO>> GetServiceDropdown();
        bool IsProductExits(string uid);

    }
}
