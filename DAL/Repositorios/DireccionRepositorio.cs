using DAL.Contractos;
using DAL.Data;
using ENTIDADES.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
	public class DireccionRepositorio : IDireccionRepository
	{
		private readonly RentmovieContext _dbContext;
		public DireccionRepositorio(RentmovieContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<bool> Create(Direccion entity)
		{
			try
			{
				_dbContext.Add(entity);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				return false;
			}

		}

		public async Task<bool> Delete(int id)
		{
			try
			{
				var direccion = await _dbContext.Direccions.FindAsync(id);
				if(direccion is null)
				{
					return false;
				}

				_dbContext.Remove(direccion);
				await _dbContext.SaveChangesAsync();
				return true;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				return false;
			}
		}

		public async Task<IEnumerable<Direccion>> GetAll()
		{
			try
			{
				var direccion = await _dbContext.Direccions.ToListAsync();
				return direccion;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				return null;
			}
		}

		public async Task<Direccion> GetById(int id)
		{
			try
			{
				var direccion = await _dbContext.Direccions.Where(x => x.IdDireccion == id).FirstOrDefaultAsync();
				return direccion;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception: {ex.Message}");
				return null;
			}
		}

		public async Task<bool> Update(Direccion entity)
		{

			try
			{
				var data = await _dbContext.Direccions.FirstOrDefaultAsync(x => x.IdDireccion == entity.IdDireccion);
				if (data == null)
				{
					throw new Exception("This direction doesnt exist");
				}
				else
				{
					data.DireccionCalle = entity.DireccionCalle;
					data.DireccionNumeroCasa = entity.DireccionNumeroCasa;
					data.DireccionMunicipio = entity.DireccionMunicipio;
					data.DireccionSector = entity.DireccionSector;
				
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
	}
}
