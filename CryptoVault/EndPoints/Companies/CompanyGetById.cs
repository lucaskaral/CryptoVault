using CryptoVault.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVault.EndPoints.Companies
{
    public class CompanyGetById
    {
        public static string Template => "/companies/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var company = context.Companies
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (company == null)
            {
                Dictionary<string, string[]> errors = new Dictionary<string, string[]>();
                string[] messages = new string[] { $"Company not found." };
                errors.Add("errors", messages);
                return Results.ValidationProblem(errors);
            }

            var companyResponse = new CompanyResponse
            {
                Id = company.Id,
                cnpj = company.cnpj,
                Name = company.Name,
                Certificates = company.Certificates,
                KeyPairs = company.KeyPairs
            };

            return Results.Ok(companyResponse);
        }
    }
}
