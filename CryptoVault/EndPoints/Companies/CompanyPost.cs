using CryptoVault.Domain.Companies;
using CryptoVault.Infra.Data;

namespace CryptoVault.EndPoints.Companies
{
    public class CompanyPost
    {
        public static string Template => "/companies";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(CompanyRequest companyRequest, ApplicationDbContext context)
        {
            var company = new Company(companyRequest.Name, companyRequest.cnpj);

            if (!company.IsValid)
            {
                return Results.ValidationProblem(company.Notifications.ConvertToProblemDetails());
            }

            var companyAux = context.Companies
                .Where(company => company.cnpj == companyRequest.cnpj)
                .ToList();

            if (companyAux.Count > 0) 
            {
                Dictionary<string, string[]> errors = new Dictionary<string, string[]>();
                string[] messages = new string[] { $"CPF Já cadastrado." };
                errors.Add("errors", messages);
                return Results.ValidationProblem(errors);
            }


            context.Companies.Add(company);
            context.SaveChanges();

            return Results.Created($"/companies/{company.Id}", company.Id);
        }

    }
}
