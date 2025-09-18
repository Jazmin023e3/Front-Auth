using FrontAuth.WebApp.Controllers;
using FrontAuth.WebApp.DTOs;
using FrontAuth.WebApp.DTOs.UsuarioDTOs;
using FrontAuth.WebApp.Helpers;
using FrontAuth.WebApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FrontAuth.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        // GET: Mostrar Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
            {
                ViewBag.Error = "Credenciales inválidas";
                return View();
            }

            // Crear y firmar los claims usando el helper
            var principal = ClaimsHelper.CrearClaimsPrincipal(result);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        // POST: Registro
        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioRegistroDTO dto)
        {
            var result = await _authService.RegistrarAsync(dto);

            if (result == null || result.Id <= 0)
            {
                ViewBag.Error = "Error al registrar";
                return View();
            }

            // Crear y firmar los claims usando el helper
            var principal = ClaimsHelper.CrearClaimsPrincipal(result);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        // GET: Mostrar Registro
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        // Logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}