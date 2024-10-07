using CryptoVault.Domain.Companies;
using CryptoVault.Infra.Data;
using Microsoft.AspNetCore.Identity;

namespace CryptoVault.EndPoints.Users
{
    public class EntityCompanyPost
    {
        public static string Template => "/entityuser";
        public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action(CompanyRequest companyRequest)
        {
            var company = new Company { Name = companyRequest.Name, cnpj = companyRequest.cnpj };
            var result = RouteCreationException create repository here

            if (!result.Succeeded)
            {
                return Results.BadRequest(result.Errors.First());
            }
            return Results.Created($"/users/{user.Id}", user.Id);
        }
    }
}
