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

	public int? Edad
	{
		get
		{
			if (FechaNac.HasValue)
			{
				// Calcula la edad a partir de la fecha de nacimiento
				int edad = DateTime.Now.Year - FechaNac.Value.Year;
				if (DateTime.Now < FechaNac.Value.AddYears(edad))
				{
					edad--; // Todavía no ha celebrado su cumpleaños este año
				}
				return edad;
			}
			return null; // Devuelve null si no hay fecha de nacimiento
		}
	}


	public string? UserName { get; set; }


    public string? Contraseña { get; set; }

    public int? DireccionId { get; set; }

    public virtual ICollection<Alquiler> Alquilers { get; set; } = new List<Alquiler>();

    public virtual Direccion? Direccion { get; set; }

	public int? RoleId { get; set; }

	public virtual Role? Role { get; set; }
}
