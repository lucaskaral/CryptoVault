using CryptoVault.Domain.Certificates;
using CryptoVault.Domain.Keys;

namespace CryptoVault.Domain.Companies
{
    public class Company
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string cnpj { get; set; }
        public List<KeyPair>? KeyPairs { get; set; }
        public List<Certificate>? Certificates { get; set; }
    }
}
