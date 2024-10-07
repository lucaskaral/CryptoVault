using CryptoVault.Domain.Keys;

namespace CryptoVault.Domain.Certificates
{
    public class Certificate
    {
        public string certificate {  get; set; }
        public KeyPair signedBy { get; set; }
    }
}
