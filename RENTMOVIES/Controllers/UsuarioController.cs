using AutoMapper;
using BAL.Services.IServices;
using DAL.Contractos;
using DAL.DTO.Response;
using ENTIDADES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace RENTMOVIES.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repository;
        private readonly IMapper _mapper;
        private readonly IAuthServices _authService;
        private readonly IEmailService _emailService;

        public UsuarioController(IUsuarioRepositorio repository, IMapper mapper, IAuthServices authServices, IEmailService emailService)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._authService = authServices;
            this._emailService = emailService;
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

                //Validate if user already exist
                Usuario emailExiste = await _repository.GetByEmail(usuarioDTO.Email);

                if (emailExiste != null) return BadRequest(new { msg = "The email already exists" });

                await _repository.Create(usuario);

                await SendVerificationEmail(usuarioDTO);

                return Ok(new { msg = "Account Created, Check your email" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción: {ex.Message}");
                return BadRequest(ex);
            }
        }

        //CONFIRM EMAIL

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
                return BadRequest(new { msg = "Invalid email confirmation URL" });


            var user = await _repository.GetByUserName(userId);

            if (user == null)
                return NotFound($"Unable to load the user '{userId}'.");

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

            var userEmail = await _repository.GetByEmail(code);

            if (userEmail == null)
                return NotFound($"There has been an error confirming your email.");

            return Ok("Thank you for confirming your email.");

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
            catch (Exception ex)
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

        private async Task SendVerificationEmail(UsuarioResponseDTO user)
        {
            var verificationCode = _authService.GenerateJWT(user.Email);
            verificationCode = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(verificationCode));

            var callbackUrl = $"{Request.Scheme}://{Request.Host}{Url.Action("ConfirmEmail", controller: "Usuario", new { userId = user.UserName, code = verificationCode })}";

            var emailBody = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>";

            await _emailService.SendEmailAsync(user.Email, "Confirm your email", emailBody);

        }

    }
}
