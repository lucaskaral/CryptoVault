namespace CryptoVault.EndPoints.Users
{
    public class UserRequest
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Identification { get; set; }//CPF
    }
}
