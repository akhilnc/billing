using billing.Data.Generics.Enum;
using billing.Data.Generics.General;

namespace billing.Infrastructure.Security.Token
{
    public interface IToken
    {
        TokenOut GenerateToken<T>(AppTokenSettings<T> tokenSettings);
        T ValidateAndDecode<T>(string jwt, TokenType type);
    }
}