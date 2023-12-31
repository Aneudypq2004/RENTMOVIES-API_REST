﻿using ENTIDADES.Models;
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

		Task<Usuario> GetByUserName(string name);
		Task<Usuario> GetByEmail(string name);

        Task<Usuario> GetByToken(string token);

		Task<bool> ConfirmUser(Usuario entity);

		Task<String> ForgotPassword(Usuario entity);

		Task<bool> ChangePassword(Usuario usuario, string password);
    }
}
