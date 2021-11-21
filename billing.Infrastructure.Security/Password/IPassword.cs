using billing.Data.Generics.AppSettings;

namespace billing.Infrastructure.Security.Password
{
    public interface IPassword
    {
        public string GenerateRandomPassword(PasswordSettings settings);
        public string GenerateOTP(int? length);
    }
}