using billing.Data.DTOs.Dropdown;
using billing.Data.DTOs.Masters;
using billing.Data.Generics;
using billing.Data.Generics.General;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Service.Masters.Customer
{
   public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetAll();
        Task<CustomerDTO> GetById(string uId);
        Task<Envelope> Save(CustomerDTO input);
        Task<Envelope> Update(CustomerDTO input);
        Task<Envelope> Delete(string uId);
        Task<Envelope> CheckDuplication(DuplicateValidation input);
        Task<IEnumerable<CustomerDropdownDTO>> GetCustomerDropdown();
    }
}
