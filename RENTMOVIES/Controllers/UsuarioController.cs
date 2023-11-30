using DAL.Contractos;
using DAL.Profiles;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ENTIDADES.Models;
using AutoMapper;
using DAL.DTO.Response;
using DAL.DTO.Request;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BAL.Services.IServices;

namespace RENTMOVIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repository;
        private readonly IMapper _mapper;
        private readonly IAuthServices _authService;
        private readonly IDireccionRepository _directionRepository;


        public UsuarioController(IUsuarioRepositorio repository, IMapper mapper, IAuthServices authServices, IDireccionRepository direccionRepository)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._authService = authServices;
            this._directionRepository = direccionRepository;
        }

        // Create a new User

        [HttpPost("Registrar")]
        public async Task<ActionResult> Register([FromBody] UsuarioResponseDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var usuario = _mapper.Map<Usuario>(usuarioDTO);

                await _repository.Create(usuario);

                return Ok(new { msg = "Account Created, Check your email" });
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                return BadRequest(ex);
            }
        }

        // SIGN IN METHOD

        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] UserLogin usuario)
        {
            try
            {

                Usuario user = await _repository.GetByEmail(usuario.Email);

                if (user is null)
                {
                    return BadRequest(new { msg = "The user doesnt exists" });
                }

                // Validate if the user is verified
                // REVISAR esta parte
                if (!user.Verificado)
                {
                    return Unauthorized(new { msg = "Please, confirm your account" });

                }

                // Validate the password

                bool ValidPass = BCrypt.Net.BCrypt.Verify(usuario.Password, user.Contraseña);

                if (!ValidPass)
                {
                    return Unauthorized(new { msg = "The password is not valid" });
                }

                // return access token

                return Ok(new
                {
                    token = _authService.GenerateJWT(user.Email)

                });

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                return BadRequest();
            }
        }

        // Confirm account

        [HttpGet("Confirm/{token}")]
        public async Task<ActionResult> ConfirmAccount([FromRoute] String token)
        {
            try
            {
                Usuario user = await _repository.GetByToken(token);

                if(user is null)
                {
                    return NotFound(new { msg = "The token is not valid" });
                }

                await _repository.ConfirmUser(user);

                return Ok(new { msg = "Account verified successfully" });

            }
            catch (Exception message)
            {

                return BadRequest(new { msg = message }); 
            }

        }

        // Forgot PASSWORD

        [HttpPost("Forgot-password")]
        public async Task<ActionResult> ForgotPassword([FromRoute] String token)
        {
            try
            {
                Usuario user = await _repository.GetByToken(token);

                if (user is null)
                {
                    return NotFound(new { msg = "The token is not valid" });
                }

                await _repository.ConfirmUser(user);

                return Ok(new { msg = "Account verified successfully" });

            }
            catch (Exception message)
            {

                return BadRequest(new { msg = message });
            }

        }


        // Change password

        [HttpPatch("Change-password/{token}")]
        public async Task<ActionResult> ChangePassword([FromRoute] String token)
        {
            try
            {
                Usuario user = await _repository.GetByToken(token);

                if (user is null)
                {
                    return NotFound(new { msg = "The token is not valid" });
                }

                await _repository.ConfirmUser(user);

                return Ok(new { msg = "Account verified successfully" });

            }
            catch (Exception message)
            {

                return BadRequest(new { msg = message });
            }

        }

    }
}
