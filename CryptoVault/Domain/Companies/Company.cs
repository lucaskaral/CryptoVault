using CryptoVault.Domain.Certificates;
using CryptoVault.Domain.Keys;
using CryptoVault.Domain.Users;
using Flunt.Notifications;
using Flunt.Validations;

namespace CryptoVault.Domain.Companies
{
    public class Company : Notifiable<Notification>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string cnpj { get; set; }
        public List<KeyPair>? KeyPairs { get; set; }
        public List<Certificate>? Certificates { get; set; }

        public Company(string name, string cnpj)
        {
            var contract = new Contract<Company>()
                .IsNotNullOrEmpty(name, "Name", "Nome é obrigatório!")
                .IsGreaterOrEqualsThan(cnpj, 14, "CNPJ", "CNPJ deve conter 14 dígitos");

            AddNotifications(contract);

            Name = name;
            this.cnpj = cnpj;
        }
    }
}
