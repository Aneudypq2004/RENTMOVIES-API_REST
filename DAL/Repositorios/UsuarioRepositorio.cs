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
        // CREATE A USER

        public async Task<bool> Create(Usuario entity)
        {
            try
            {
                entity.Edad = CalcularEdad(entity);

                entity.Token = generarToken();

                _dbContext.Add(entity);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return false;
            }
        }

        // UPDATE THE USER

        public async Task<bool> Update(Usuario entity)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return false;
            }

        }

        // Delete User
        public async Task<bool> Delete(int id)
        {
            try
            {
			var usuario = await _dbContext.Usuarios.FindAsync(id);
				
				if (usuario == null)
				{
					return false;
				}
				_dbContext.Remove(usuario);
				await _dbContext.SaveChangesAsync();
				return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return false;
            }
        }


        // VALIDATE THE USER

        public async Task<bool> ConfirmUser(Usuario usuario)
        {
            try
            {
                // UPDATE THE USER

                usuario.Token = null;

                usuario.Verificado = true;

                _dbContext.Update(usuario);

                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception msg)
            {
                throw new Exception("We cant validate the user" + msg.Message);
            }

        }

        // FORGOT THE PASSWORD

        public async Task<String> ForgotPassword(Usuario usuario)
        {
            try
            {
                // UPDATE THE USER WITH THE NEW TOKEN

                usuario.Token = generarToken();

                _dbContext.Update(usuario);

                await _dbContext.SaveChangesAsync();

                return usuario.Token;
            }
            catch (Exception msg)
            {
                throw new Exception("We cant validate the user" + msg.Message);
            }

        }

        // Change the user Password

        public async Task<String> ChangePassword(Usuario usuario)
        {
            try
            {
                // UPDATE THE USER WITH THE NEW TOKEN

                usuario.Token = null;

                // IMPLEMENT LOGIG

                _dbContext.Update(usuario);

                await _dbContext.SaveChangesAsync();

                return usuario.Token;
            }
            catch (Exception msg)
            {
                throw new Exception("We cant validate the user" + msg.Message);
            }

        }

        // GET THE USER

        public async Task<Usuario> GetByUserName(string name)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.Where(n => n.UserName == name).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }

        }
        public async Task<IEnumerable<Usuario>> GetAll()
        {
            try
            {
                var usuario = await _dbContext.Usuarios.ToListAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }

        }

        public async Task<Usuario> GetById(int id)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.Where(n => n.Id == id).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }
        }

        public async Task<Usuario> GetByName(string name)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.Where(n => n.Nombre == name).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }
        }

        public async Task<Usuario> GetByEmail(string name)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.Where(n => n.Email == name).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return null;
            }
        }

        // FIND A USER WITH THE TOKEN
        public async Task<Usuario> GetByToken(string token)
        {
            try
            {
                var usuario = await _dbContext.Usuarios.Where(user => user.Token == token).FirstOrDefaultAsync();
                return usuario;
            }
            catch (Exception)
            {
                return null;
            }

        }

        // Helpers

        public int CalcularEdad(Usuario entity)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine($"Se ha producido una excepción: {ex.Message}");
                return 0;
            }
        }
        public string generarToken()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        //	Get the user
    }
}


