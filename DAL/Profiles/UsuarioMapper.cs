using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES.Models;
using DAL.DTO.Response;
using DAL.DTO.Request;
namespace DAL.Profiles
{
    public class UsuarioMapper:Profile
	{ 

		public UsuarioMapper() {

			CreateMap<UsuarioResponseDTO, Usuario>()
		.ForMember(dest => dest.Id, opt => opt.Ignore())
		.ForMember(dest => dest.Edad, opt => opt.Ignore())
		.ForMember(dest => dest.Alquilers, opt => opt.Ignore());

			CreateMap<Usuario, UsuarioRequestDTO>().ReverseMap();

		}



	}
}
