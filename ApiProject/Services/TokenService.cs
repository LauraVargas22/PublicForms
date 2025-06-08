using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;


namespace APIProject.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            // Guardamos la configuración de appsettings
            _configuration = configuration;
        }

        public string GenerarToken(string usuarioNombre, string usuarioRol)
        {
            // Creamos la info que va dentro del token (claims)
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuarioNombre), // Nombre del usuario
                new Claim(ClaimTypes.Role, usuarioRol), // Rol del usuario
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // ID único del token
            };

            // Preparamos la clave secreta
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Decimos con qué algoritmo vamos a firmar el token
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Armamos el token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: creds
            );

            // Convertimos el token a string y lo devolvemos
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}