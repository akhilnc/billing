using billing.Data.DbContexts;
using billing.Data.Models;
using billing.Data.Repositories.Base;

namespace billing.Data.Repositories.Admin.Token
{
    public class TokenRepo : RepositoryBase<AdminUserRefreshToken>, ITokenRepo
    {
        private readonly BillingAppContext _appContext;
        public TokenRepo(BillingAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
    }
}
