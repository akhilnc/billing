using billing.Data.DTOs;
using billing.Data.Generics;
using billing.Data.Generics.General;
using System.Threading.Tasks;

namespace billing.Service.Authentication
{
    public interface IAuthenticationService
    {
        Task<Envelope<LoginResponse>> Login(LoginDTO input);

        Task<Envelope<TokenResponse>> GetNewToken(string refreshToken);
    }
}