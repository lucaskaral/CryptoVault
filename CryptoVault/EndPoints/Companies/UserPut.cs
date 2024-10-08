﻿using CryptoVault.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace CryptoVault.EndPoints.Companies
{
    public class UserPut
    {
        public static string Template => "/companies/{id:guid}";
        public static string[] Methods => new string[] { HttpMethod.Put.ToString() };
        public static Delegate Handle => Action;

        public static IResult Action([FromRoute] Guid id, CompanyRequest userRequest, ApplicationDbContext context)
        {
            var company = context.Companies
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (company == null)
            {
                Dictionary<string, string[]> errors = new Dictionary<string, string[]>();
                string[] messages = new string[] { $"Companhia inválida." };
                errors.Add("errors", messages);
                return Results.ValidationProblem(errors);
            }
            company.Name = userRequest.Name;
            company.cnpj = userRequest.cnpj;

            if (!company.IsValid)
            {
                return Results.ValidationProblem(company.Notifications.ConvertToProblemDetails());
            }

            
            context.SaveChanges();

            return Results.Ok();
        }
    }
}

