using billing.Data.DTOs.Dropdown;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.Service
{
    public  interface IServiceService
    {
        Task<IEnumerable<ServiceDTO>> GetAll();
        Task<ServiceDTO> GetById(string uId);
        Task<Envelope> Save(ServiceDTO input);
        Task<Envelope> Update(ServiceDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
        Task<IEnumerable<ServiceDropdownDTO>> GetServiceDropdown();
        bool IsProductExits(string uId);

    }
}
