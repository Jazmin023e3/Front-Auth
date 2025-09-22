using FrontAuth.WebApp.DTOs.UsuarioDTOs;
using System.Globalization;
using System.Security.Claims;

namespace Front_Auth.DTOs.UsuarioDTOs
{
    public class LoginResponseDTO : UsuarioDTO
    {
        public String Token { get; set; }
    }
}
