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
    public class PerfilesMapper:Profile
	{ 

		public PerfilesMapper() {

			//UsuarioMapper
			CreateMap<UsuarioResponseDTO, Usuario>()
			.ForMember(dest => dest.Contraseña, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Contraseña)));
			CreateMap<Usuario, UsuarioRequestDTO>().ReverseMap();

			//DireccionMapper
			CreateMap<DireccionResponseDTO, Direccion>();
			CreateMap<Direccion, DireccionRequestDTO>();

			//AlquilerMapper
			//Mejor crear una vista en la base de datos e importarla
			CreateMap<AlquilerResponseDTO, Alquiler>();
			CreateMap<Alquiler, AlquilerRequestDTO>();

		}



	}
}
