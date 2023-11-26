using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Contractos;
using ENTIDADES.Models;
using DAL.Profiles;
using DAL.Data;
using DAL.Repositorios;


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
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
			builder.Services.AddAutoMapper(typeof(UsuarioMapper));


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