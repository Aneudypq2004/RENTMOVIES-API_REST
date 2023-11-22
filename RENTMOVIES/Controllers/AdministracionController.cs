using DAL.Contractos;
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

		public AdministracionController(IUsuarioRepositorio repository)
		{
			_repository = repository;
		}
		

		

	}
}
