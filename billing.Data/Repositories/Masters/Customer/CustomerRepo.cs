using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
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
        /// Gets the customer by u identifier.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns></returns>
        public async Task<MstCustomer> GetCustomerByUId(string uid)
        {
            return await _appContext.MstCustomer
                .SingleOrDefaultAsync(u => u.UId == uid);
        }

        #endregion
    }
}
