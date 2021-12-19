namespace Application.Security
{
    public static class PasswordHasher
    {
        public static bool VerifyHash(string inputPassword, string cardPassword) => BCrypt.Net.BCrypt.Verify(inputPassword, cardPassword);
        public static string HashPassword(string inputPassword) => BCrypt.Net.BCrypt.HashPassword(inputPassword);
    }
}
