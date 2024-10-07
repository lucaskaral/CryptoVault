using CryptoVault.Domain.Certificates;
using CryptoVault.Domain.Keys;

namespace CryptoVault.EndPoints.Companies
{
    public class CompanyResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string cnpj { get; set; }
        public List<KeyPair>? KeyPairs { get; set; }
        public List<Certificate>? Certificates { get; set; }

    }
}
