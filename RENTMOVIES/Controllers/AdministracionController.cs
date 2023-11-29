using AutoMapper;
using DAL.Contractos;
using DAL.DTO.Request;
using ENTIDADES.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RENTMOVIES.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdministracionController : ControllerBase
	{

		private readonly IUsuarioRepositorio _repository;
		private readonly IMapper _mapper;

		public AdministracionController(IUsuarioRepositorio repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		[Route("ListaUsuarios")]
		public async Task<ActionResult> GetAll()
		{
			try
			{
				var usuariosdb = await _repository.GetAll();
				var usuario = _mapper.Map<List<UsuarioRequestDTO>>(usuariosdb);
				return Ok(usuario);
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Se ha producido una excepción durante la creacion del usuario: {ex.Message}");
				return StatusCode(500,"Ocurrió un error interno en el servidor");
			}
		}
		


	}
}
