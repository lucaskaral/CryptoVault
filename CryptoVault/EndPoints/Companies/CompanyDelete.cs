using CryptoVault.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVault.EndPoints.Companies
{
    public class CompanyDelete
    {
        public static string Template => "/companies/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, ApplicationDbContext context)
        {
            var company = context.Companies
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (company == null)
            {
                return Results.Ok();
            }

            context.Remove(company);
            context.SaveChanges();

            return Results.Ok();
        }
    }
}
