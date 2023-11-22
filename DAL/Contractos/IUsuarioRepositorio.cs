using ENTIDADES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contractos
{
	public interface IUsuarioRepositorio: IGenericRepository<Usuario>
	{
		Task<Usuario> GetByName(string name);

	}
}
