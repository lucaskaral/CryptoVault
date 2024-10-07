namespace CryptoVault.EndPoints.Users
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Identification { get; set; }//CPF

    }
}
