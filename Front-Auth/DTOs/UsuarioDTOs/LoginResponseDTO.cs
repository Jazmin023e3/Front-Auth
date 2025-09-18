using FrontAuth.WebApp.DTOs.UsuarioDTOs;
using System.Globalization;

namespace Front_Auth.DTOs.UsuarioDTOs
{
    public class LoginResponseDTO : UsuarioLoginDTO
    {
        public String Token { get; set; }
        public int Id { get; internal set; }
    }
}
