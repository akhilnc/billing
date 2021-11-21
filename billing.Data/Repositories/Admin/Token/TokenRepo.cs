using billing.Data.DbContexts;
using billing.Data.Models;
using billing.Data.Repositories.Base;

namespace billing.Data.Repositories.Admin.Token
{
    public class TokenRepo : RepositoryBase<AdminUserRefreshToken>, ITokenRepo
    {
        private readonly LAppContext _appContext;
        public TokenRepo(LAppContext appContext) : base(appContext)
        {
            _appContext = appContext;
        }
    }
}
