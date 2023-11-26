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
			.ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Contraseña)));

			CreateMap<Usuario, UsuarioRequestDTO>().ReverseMap();

		}



	}
}
