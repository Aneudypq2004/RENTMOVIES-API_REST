using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contractos
{
	public interface IGenericRepository<Entity> where Entity : class
	{
		public Task <Entity> GetById(int id);
		public Task<bool> Create(Entity entity);
		public Task<bool> Update(Entity entity);
		public Task<bool> Delete(int id);
		public Task<IEnumerable<Entity>> GetAll();

		public Task<bool> ConfirmUser(Entity entity );

	}
}
