namespace EventApi.Application.Utils
{
    public static class EncryptPasswordService
    {
        public static string EncryptPasswordHash(string password)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            return passwordHash;
        }
        public static bool VerifyPassword(string password, string password2)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, password2);
            return verified;
        }
    }
}
