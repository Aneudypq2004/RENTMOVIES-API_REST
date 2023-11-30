using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Contractos;
using ENTIDADES.Models;
using DAL.Profiles;
using DAL.Data;
using DAL.Repositorios;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Org.BouncyCastle.Utilities;
using BAL.Services.IServices;
using BAL.Services;

namespace RENTMOVIES
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<RentmovieContext>(opciones =>
            {
                opciones.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
            });

            //Email

            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.AddSingleton<IEmailService, EmailService>();

            // Add JWT services

            builder.Services.AddSingleton<IAuthServices, AuthService>();

            builder.Services.AddAuthorization();

            builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
            {
                // GET THE SECRET KEY

                var SecretKey = builder.Configuration.GetSection("SecretKeyJWT").Value;

                Byte[] signinKeyBytes = Encoding.UTF8.GetBytes(SecretKey);

                SecurityKey signingKey = new SymmetricSecurityKey(signinKeyBytes);

                // What we want validate

                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = signingKey,
                };
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IDireccionRepository, DireccionRepositorio>();
            builder.Services.AddAutoMapper(typeof(PerfilesMapper));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}