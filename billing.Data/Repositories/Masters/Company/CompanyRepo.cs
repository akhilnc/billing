using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Company
{
  public  class CompanyRepo : RepositoryBase<CompanySettings>, ICompanyRepo 
    {
        private readonly DbContexts.BillingAppContext _appContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyRepo"/> class.
        /// </summary>
        /// <param name="appContext">The application context.</param>
        public CompanyRepo(DbContexts.BillingAppContext appContext) : base(appContext)
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
                $"SELECT * FROM company_settings WHERE  {input.ColumnName} = '{input.Value}' AND {input.IdentifierColumnName} <> '{input.Identifier}' ";
            var result = await _appContext.MstService.FromSqlRaw(query).ToListAsync();
            return result.Count == 0;
        }

        /// <summary>
        /// Gets the company by u identifier.
        /// </summary>
        /// <param name="Uid">The uid.</param>
        /// <returns></returns>
        public async Task<CompanySettings> GetCompanyByUId(string Uid)
        {
            return await _appContext.CompanySettings
                .SingleOrDefaultAsync(u => u.UId== Uid);
        }

        #endregion
    }
}
