using billing.Data.DTOs.Dropdown;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Service.Masters.Customer
{
   public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> GetById(string uId);
        Task<CustomerDTO> GetByIdCustom(int id);
        Task<Envelope<int>> Save(CustomerDTO input);
        Task<Envelope<int>> Update(CustomerDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
        Task<IEnumerable<CustomerDropdownDTO>> GetCustomerDropdown();
        bool IsCoustomerExits(string uId);
    }
}
