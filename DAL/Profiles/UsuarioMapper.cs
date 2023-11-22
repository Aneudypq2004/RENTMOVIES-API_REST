using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES.Models;
using DAL.DTO.Response;
namespace DAL.Profiles
{
    public class UsuarioMapper:Profile
	{ 

		public UsuarioMapper() {
		
			CreateMap<UsuarioDTO, Usuario>()
			.ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignorar la propiedad Id
			.ForMember(dest => dest.Edad, opt => opt.Ignore()) // Ignorar la propiedad Edad
			.ForMember(dest => dest.Alquilers, opt => opt.Ignore()); // Ignorar la propiedad Alquilers

		
		}
		

		
	}
}
