using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTO
{
	public class UsuarioDTO
	{
		[Required(ErrorMessage ="Coloque un nombre.")]
		public string? Nombre { get; set; }
		[Required(ErrorMessage = "Coloque un apellido.")]
		public string? Apellido { get; set; }
		[Required(ErrorMessage = "Coloque su fecha de nacimiento.")]
		public DateTime? FechaNac { get; set; }
		[Required(ErrorMessage = "Coloque un nombre de usuario.")]
		public string? UserName { get; set; }
		[Required(ErrorMessage = "Coloque una contraseña.")]
		public string? Contraseña { get; set; }
		[Required(ErrorMessage ="La contraseña debe coincidir.")]
		[Compare("Contraseña")]
		public string? ContraseñaConfirmacion { get; set; }
		[Required(ErrorMessage = "Coloque un municipio.")]
		public string? DireccionMunicipio { get; set; }
		[Required(ErrorMessage = "Coloque un sector.")]
		public string? DireccionSector { get; set; }
		[Required(ErrorMessage = "Coloque una calle")]
		public string? DireccionCalle { get; set; }
		[Required(ErrorMessage = "Coloque un numero de casa.")]
		public string? DireccionNumeroCasa { get; set; }
	}
}
