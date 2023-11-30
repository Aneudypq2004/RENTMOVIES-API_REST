using DAL.Contractos;
using ENTIDADES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorios
{
	public class AlquilerRepositorio : IAlquilerRepository
	{
		public Task<bool> Create(Alquiler entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Alquiler>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<Alquiler> GetById(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Update(Alquiler entity)
		{
			throw new NotImplementedException();
		}
	}
}
