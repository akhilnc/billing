using billing.Data.DTOs.Dropdown;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Customer
{
    public interface ICustomerRepo : IRepositoryBase<MstCustomer>
    {
        Task<bool> CheckDuplication(DuplicateValidation input);
        Task<MstCustomer> GetUserById(string userId);
        Task<MstCustomer> GetUserByName(string userName);
        Task<IEnumerable<CustomerDropdownDTO>> GetCustomerDropdown();
    }
}
