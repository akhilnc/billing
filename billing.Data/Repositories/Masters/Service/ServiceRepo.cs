
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
        /// <param name="serviceId">The user identifier.</param>
        /// <returns></returns>
        public async Task<MstService> GetUserById(string serviceId)
        {
            return await _appContext.MstService
                .SingleOrDefaultAsync(u => u.UId == serviceId);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="serviceName">The user identifier.</param>
        /// <returns></returns>
        public async Task<MstService> GetUserByName(string serviceName)
        {
            return await _appContext.MstService
                .SingleOrDefaultAsync(u => u.Name == serviceName);
        }
        #endregion
    }
}
