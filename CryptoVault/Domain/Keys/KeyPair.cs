namespace CryptoVault.Domain.Keys
{
    public class KeyPair
    {
        public required string PrivateKey { get; set; }
        public required string PublicKey { get; set; }
    }
}
