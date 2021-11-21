using billing.Data.Generics.General;

namespace billing.Infrastructure.Common.Utlilities.TokenUserClaims
{
    public interface ITokenUserClaims
    {
        UserBase GetClaims();
    }
}