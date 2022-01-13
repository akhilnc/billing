
using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.Service
{
    public  class ServiceRepo:RepositoryBase<MstService>,IServiceRepo
    {
        private readonly DbContexts.BillingAppContext _appContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepo"/> class.
        /// </summary>
        /// <param name="appContext">The application context.</param>
        public ServiceRepo(DbContexts.BillingAppContext appContext) : base(appContext)
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
                $"SELECT * FROM mst_service WHERE  {input.ColumnName} = '{input.Value}' AND {input.IdentifierColumnName} <> '{input.Identifier}' ";
            var result = await _appContext.MstService.FromSqlRaw(query).ToListAsync();
            return result.Count == 0;
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="uid">Gets service by uid</param>
        /// <returns></returns>
        public async Task<MstService> GetServiceByUId(string uid)
        {
            return await _appContext.MstService
                .SingleOrDefaultAsync(u => u.UId == uid);
        }

        #endregion
    }
}
