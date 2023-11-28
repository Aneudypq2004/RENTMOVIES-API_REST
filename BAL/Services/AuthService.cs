using BAL.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace BAL.Services
{
    public class AuthService : IAuthServices
    {
        public readonly IConfiguration _config;

        public AuthService(IConfiguration configuration)
        {
            this._config = configuration;

        }

        public string GenerateJWT(string email)
        {

            Byte[] signinKeyBytes = Encoding.UTF8.GetBytes(_config.GetSection("SecretKeyJWT").Value);

            SigningCredentials SigningCrendetial = new(new SymmetricSecurityKey(signinKeyBytes), SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Expires = DateTime.Now.AddDays(10),

                Subject = new ClaimsIdentity(new Claim[]
                {
                   new Claim(ClaimTypes.Email, email)

                }),

                SigningCredentials = SigningCrendetial

            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
