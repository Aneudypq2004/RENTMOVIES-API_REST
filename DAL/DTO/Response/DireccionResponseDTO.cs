using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Response
{
    public class DireccionResponseDTO
    {

        [Required(ErrorMessage = "Coloque un municipio.")]
        public string DireccionMunicipio { get; set; }
        [Required(ErrorMessage = "Coloque un sector.")]
        public string DireccionSector { get; set; }
        [Required(ErrorMessage = "Coloque una calle")]
        public string DireccionCalle { get; set; }
        [Required(ErrorMessage = "Coloque un numero de casa.")]
        public string DireccionNumeroCasa { get; set; }
    }
}
