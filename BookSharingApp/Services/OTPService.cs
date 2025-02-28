namespace BookSharingApp.Services
{
    public class OTPService
    {
        private static readonly Random random = new();
        public static string GenerateOTP()
        {
            return random.Next(100000,999999).ToString();
        }
    }
}
