using System;
using System.Collections.Generic;
using System.Data;

namespace ENTIDADES.Models;

public  class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public DateTime? FechaNac { get; set; }

	public int? Edad { get; set;}

	public string? UserName { get; set; }
	
	public string? Email { get; set; }

	public string? Token { get; set; }

	public bool? Verificado { get; set; }

	public string? Contraseña { get; set; }

    public int? DireccionId { get; set; }

    public virtual ICollection<Alquiler> Alquilers { get; set; } = new List<Alquiler>();

    public virtual Direccion? Direccion { get; set; }

	public int? RoleId { get; set; } = 2;

	public virtual Role? Role { get; set; }
}
