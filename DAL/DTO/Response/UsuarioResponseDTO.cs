using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Response
{
    public class UsuarioResponseDTO
    {
        [Required(ErrorMessage = "Coloque un nombre.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Coloque un apellido.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Coloque su fecha de nacimiento.")]
        public DateTime? FechaNac { get; set; }
        [Required(ErrorMessage = "Coloque un nombre de usuario.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Coloque una contraseña.")]
        public string Contraseña { get; set; }

		[Required(ErrorMessage = "Coloque un correo.")]
		public string Email { get; set; }
	}
}
