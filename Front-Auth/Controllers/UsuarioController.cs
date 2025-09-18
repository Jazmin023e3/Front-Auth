using Microsoft.AspNetCore.Mvc;
using FrontAuth.WebApp.Services;
using System.Threading.Tasks;
using FrontAuth.WebApp.DTOs.UsuarioDTOs;
using FrontAuth.WebApp.Helpers;

namespace FrontAuth.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApiService _apiService;

        public UsuarioController(ApiService apiService)
        {
            _apiService = apiService;
        }

        // Listar usuarios
        public async Task<IActionResult> Index()
        {
            var token = AuthHelper.ObtenerToken(User); // Obtener token desde Claims
            var usuarios = await _apiService.GetAllAsync<UsuarioDTO>("user/usuarios", token);
            return View(usuarios);
        }
    }
}