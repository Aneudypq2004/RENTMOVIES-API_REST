﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Request
{
	public class UsuarioRequestDTO
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string UserName { get; set; }
		public int Edad { get; set; }
		public int RoleId { get; set; }
		public string? Email { get; set; }

		public string? Token { get; set; }

		public bool? Verificado { get; set; }

	}

}
