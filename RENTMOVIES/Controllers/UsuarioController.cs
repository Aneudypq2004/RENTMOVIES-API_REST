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
	public class UsuarioController : ControllerBase
	{
		private readonly IUsuarioRepositorio _repository;
		private readonly IMapper _mapper;
		public UsuarioController(IUsuarioRepositorio repository, IMapper mapper)
		{
			this._repository = repository;
			this._mapper = mapper;
		}

		
		[HttpPost("Register")]
		
		public async Task<ActionResult> Register([FromBody] UsuarioResponseDTO usuarioDTO)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var usuario = _mapper.Map<Usuario>(usuarioDTO);
			await _repository.Create(usuario);
			return Ok();
		}
		
		[HttpPost("Login")]
		public async Task<ActionResult> Login(string username, string password)
		{
			Usuario user = await _repository.GetByUserName(username);

			if (user != null)
			{
				bool ValidPass = BCrypt.Net.BCrypt.Verify(password, user.Contraseña);
				if (ValidPass)
				{
					return Ok();
				}
				else
				{
					return BadRequest();
				}
			}
			else
			{
				return BadRequest();
			}

		}


	}
}
