using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ZuvoPetApiAzure.DTO;
using ZuvoPetApiAzure.Helpers;
using ZuvoPetApiAzure.Models;
using ZuvoPetApiAzure.Repositories;
using ZuvoPetNuget;

namespace ZuvoPetApiAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IRepositoryZuvoPet repo;
        private HelperActionServicesOAuth helper;
        public AuthController(IRepositoryZuvoPet repo, HelperActionServicesOAuth helper)
        {
            this.repo = repo;
            this.helper = helper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            Usuario usuario = await this.repo.LogInUserAsync(model.NombreUsuario, model.Contrasena);
            if (usuario == null)
            {
                return Unauthorized(new { mensaje = "Credenciales incorrectas" });
            }
            else 
            { 

                // Obtener la foto de perfil del usuario
                string fotoPerfil = await this.repo.GetFotoPerfilAsync(usuario.Id);

                // Crear credenciales para el token
                SigningCredentials credentials = new SigningCredentials(
                    this.helper.GetKeyToken(),
                    SecurityAlgorithms.HmacSha256);

                // Crear el modelo de usuario para el token
                UsuarioTokenDTO modelUsuario = new UsuarioTokenDTO
                {
                    IdUsuario = usuario.Id,
                    NombreUsuario = usuario.NombreUsuario,
                    Role = usuario.TipoUsuario
                    // Otros campos que necesites
                };

                // Convertir a JSON y cifrar los datos
                string jsonUsuario = JsonConvert.SerializeObject(modelUsuario);
                string jsonCifrado = HelperCriptography.EncryptString(jsonUsuario);

                // Crear claims para el token
                List<Claim> claims = new List<Claim>
                    {
                        new Claim("UserData", jsonCifrado),
                        new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                        new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario)
                    };

                // Generar el token JWT
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: this.helper.Issuer,
                    audience: this.helper.Audience,
                    claims: claims,
                    signingCredentials: credentials,
                    expires: DateTime.UtcNow.AddHours(2),
                    notBefore: DateTime.UtcNow);

                // Devolver el token junto con información básica del usuario
                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                    //response = new JwtSecurityTokenHandler().WriteToken(token),
                    //tipoUsuario = usuario.TipoUsuario,
                    //nombreUsuario = usuario.NombreUsuario,
                    //fotoPerfil = fotoPerfil
                });
            }
        }
    }
}
