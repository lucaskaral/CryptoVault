using CryptoVault.EndPoints.Users;
using CryptoVault.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CryptoVault
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddEntityFrameworkNpgsql()
                                .AddDbContext<ApplicationDbContext>(options => options
                                    .UseNpgsql(builder.Configuration.GetConnectionString("CryptoVaultDB")));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));


            var app = builder.Build();
            app.UseCors("corspolicy");
            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.MapMethods(UserPut.Template, UserPut.Methods, UserPut.Handle);
            app.MapMethods(UserGetAll.Template, UserGetAll.Methods, UserGetAll.Handle);
            app.MapMethods(UserPost.Template, UserPost.Methods, UserPost.Handle);
            app.MapMethods(UserDelete.Template, UserDelete.Methods, UserDelete.Handle);
            app.MapMethods(UserGetById.Template, UserGetById.Methods, UserGetById.Handle);
            app.MapMethods(UserGetByEmailAndPassword.Template, UserGetByEmailAndPassword.Methods, UserGetByEmailAndPassword.Handle);
            app.Run();
        }
    }
}