using billing.Data.Models;
using billing.Data.Repositories.Base;

namespace billing.Data.Repositories.Admin.Token
{
    public interface ITokenRepo : IRepositoryBase<AdminUserRefreshToken>
    {
    }
}
