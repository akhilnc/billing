using billing.Data.DTOs.Dropdown;
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Customer
{
    public class CustomerRepo : RepositoryBase<MstCustomer>, ICustomerRepo
    {
        private readonly DbContexts.BillingAppContext _appContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepo"/> class.
        /// </summary>
        /// <param name="appContext">The application context.</param>
        public CustomerRepo(DbContexts.BillingAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
        /// <summary>
        /// Customer Dropdown.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CustomerDropdownDTO>> GetCustomerDropdown()
        {
            return await _appContext.MstCustomer.Select(x => new CustomerDropdownDTO
            {
                Id = x.Id,
                Name=x.Name,
                VehicleNumber=x.VehicleNumber

            }).ToListAsync();
        }
        #region Validations

        /// <summary>
        /// Checks the duplication.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public async Task<bool> CheckDuplication(DuplicateValidation input)
        {
            var query =
                $"SELECT * FROM mst_customer WHERE  {input.ColumnName} = '{input.Value}' AND {input.IdentifierColumnName} <> '{input.Identifier}' ";
            var result = await _appContext.MstCustomer.FromSqlRaw(query).ToListAsync();
            return result.Count == 0;
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="costomerId">The user identifier.</param>
        /// <returns></returns>
        public async Task<MstCustomer> GetUserById(string costomerId)
        {
            return await _appContext.MstCustomer
                .SingleOrDefaultAsync(u => u.UId == costomerId);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="customerName">The user identifier.</param>
        /// <returns></returns>
        public async Task<MstCustomer> GetUserByName(string customerName)
        {
            return await _appContext.MstCustomer
                .SingleOrDefaultAsync(u => u.Name == customerName);
        }
        #endregion
    }
}
