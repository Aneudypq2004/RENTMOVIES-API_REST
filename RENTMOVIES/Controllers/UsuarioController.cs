﻿using DAL.Contractos;
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

        public UsuarioController(IUsuarioRepositorio repository, IMapper mapper, IAuthServices authServices)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._authService = authServices;
        }

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


        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] Usuario usuario)
        {
            try
            {

                Usuario user = await _repository.GetByUserName(usuario.UserName);

                if (user is null)
                {
                    return BadRequest(new { msg = "The user doesnt exists" });
                }

                // Validate the password

                bool ValidPass = BCrypt.Net.BCrypt.Verify(usuario.Contraseña, user.Contraseña);

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
    }
}
