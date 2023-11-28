using DAL.Contractos;
using DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES.Models;
using DAL.Data;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace DAL.Repositorios
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{
		private readonly RentmovieContext _dbContext; 
		private readonly IConfiguration _config;


        public UsuarioRepositorio(RentmovieContext dbContext, IConfiguration config)
		{
			_dbContext = dbContext;
			this._config = config;

		}
		public async Task<bool> Create(Usuario entity)
		{
			entity.Edad = CalcularEdad(entity);
			entity.Token = generarToken();
			_dbContext.Add(entity);

			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<bool> Delete(int id)
		{
			_dbContext.Remove(id);
			await _dbContext.SaveChangesAsync();
			return true;
		}

		public async Task<IEnumerable<Usuario>> GetAll()
		{
			var usuario = await  _dbContext.Usuarios.ToListAsync();
			return usuario;

		}

		public async Task<Usuario> GetById(int id)
		{
			var usuario = await _dbContext.Usuarios.Where(n => n.Id == id).FirstOrDefaultAsync();
			return usuario;
		}

		public async Task<Usuario> GetByName(string name)
		{
			var usuario = await _dbContext.Usuarios.Where(n => n.Nombre == name).FirstOrDefaultAsync();
			return usuario;
		}

		public async Task<bool> Update(Usuario entity)
		{
			var data = await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == entity.Id);
			if (data == null)
			{
				throw new Exception("This user doesnt exist");
			}
			else
			{
				data.Nombre = entity.Nombre;
				data.Apellido = entity.Apellido;
				data.UserName = entity.UserName;
				data.FechaNac = entity.FechaNac;
				data.Direccion = entity.Direccion;
				data.Contraseña = entity.Contraseña;
				_dbContext.Update(data);

				await _dbContext.SaveChangesAsync();
				return true;
			}


		
		}

		public async Task<Usuario> GetByUserName(string name)
		{
			var usuario = await _dbContext.Usuarios.Where(n => n.UserName == name).FirstOrDefaultAsync();
			return usuario;
		
		}

		public int CalcularEdad(Usuario entity )
		{
			if (entity.FechaNac.HasValue)
			{
				// Calcula la edad a partir de la fecha de nacimiento
				int edad = DateTime.Now.Year - entity.FechaNac.Value.Year;
				if (DateTime.Now < entity.FechaNac.Value.AddYears(edad))
				{
					edad--; // Todavía no ha celebrado su cumpleaños este año
				}
				return edad;
			}
			else
				return 0;
		}

		public string generarToken()
		{
			Guid guid = Guid.NewGuid();
			return guid.ToString();
		}
    }
}


