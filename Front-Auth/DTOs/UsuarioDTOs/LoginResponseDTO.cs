using FrontAuth.WebApp.DTOs.UsuarioDTOs;
using System.Globalization;
using System.Security.Claims;

namespace Front_Auth.DTOs.UsuarioDTOs
{
    public class LoginResponseDTO : UsuarioLoginDTO
    {
        public String Token { get; set; }
        public int Id { get; internal set; }
        public ClaimsIdentity? Rol { get; internal set; }
        public ClaimsIdentity? Nombre { get; internal set; }
    }
}
