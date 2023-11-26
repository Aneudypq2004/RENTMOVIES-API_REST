using DAL.Contractos;
using DAL.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.Models;
using AutoMapper;
using DAL.DTO.Response;
using DAL.DTO.Request;

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

		[HttpPost]
		public ActionResult Post([FromBody]UsuarioResponseDTO usuarioDTO)
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
