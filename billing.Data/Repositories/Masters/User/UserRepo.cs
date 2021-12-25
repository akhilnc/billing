using billing.Data.Generics.General;
using billing.Data.Models;
using billing.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace billing.Data.Repositories.Masters.User
{
    public class UserRepo: RepositoryBase<MstUser>,IUserRepo
    {
        private readonly DbContexts.BillingAppContext _appContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepo"/> class.
        /// </summary>
        /// <param name="appContext">The application context.</param>
        public UserRepo(DbContexts.BillingAppContext appContext) : base(appContext)
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
                $"SELECT * FROM mst_user WHERE  {input.ColumnName} = '{input.Value}' AND {input.IdentifierColumnName} <> '{input.Identifier}' ";
            var result = await _appContext.MstUser.FromSqlRaw(query).ToListAsync();
            return result.Count==0;
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<MstUser> GetUserById(string userId)
        {
            return await _appContext.MstUser
                .SingleOrDefaultAsync(u => u.UId == userId);
        }

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="userName">The user identifier.</param>
        /// <returns></returns>
        public async Task<MstUser> GetUserByName(string userName)
        {
            return await _appContext.MstUser
                .SingleOrDefaultAsync(u => u.UserName == userName);
        }
        #endregion
    }
}
