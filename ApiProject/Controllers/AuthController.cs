using Microsoft.AspNetCore.Mvc;
using APIProject.Services;


namespace APIProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Acá simulamos un login: si es admin y 1234, damos acceso
            if (request.Username == "admin" && request.Password == "1234")
            {
                // Generamos un token con rol "Admin"
                var token = _tokenService.GenerarToken(request.Username, "Admin");
                return Ok(new { token });
            }

            // Si no es válido, devolvemos 401
            return Unauthorized("Credenciales inválidas");
        }
    }

    // Clase que representa lo que llega en el body del login
    public class LoginRequest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}