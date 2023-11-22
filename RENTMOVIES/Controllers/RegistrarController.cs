using DAL.Contractos;
using DAL.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.Models;
using AutoMapper;
using DAL.DTO.Response;

namespace RENTMOVIES.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class RegistrarController : ControllerBase
	{
		private readonly IUsuarioRepositorio _repository;
		private readonly IMapper _mapper;
		public RegistrarController(IUsuarioRepositorio repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}

		[HttpGet]
		public ActionResult GetAll()
		{
			var usuariosdb = _repository.GetAll();
			return Ok(usuariosdb);
		}

		[HttpPost]

		public ActionResult Post([FromBody]UsuarioDTO usuarioDTO)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var usuario = _mapper.Map<Usuario>(usuarioDTO);
			_repository.Create(usuario);
			return Ok();
		}
	}
}
