using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TrabajoFinal.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace TrabajoFinal.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IDesayuno _desayuno;
        private readonly IAlmuerzos _almuerzo;
        private readonly ICenas _cenas;
        private readonly ISnacks _snacks;
        private readonly IUtiles _utiles;
        public AdminController(IAlmuerzos almuerzos, IDesayuno desayuno, ICenas cenas, ISnacks snacks, IUtiles utiles)
        {
            _almuerzo = almuerzos;
            _desayuno = desayuno;
            _cenas = cenas;
            _snacks = snacks;
            _utiles = utiles;
        }
        public IActionResult Desayuno()
        {
            ViewBag.Desayunos = _desayuno.GellAllProducts();
            return View();
        }
        public IActionResult Almuerzo()
        {
            ViewBag.Almuerzos = _almuerzo.GellAllProducts();
            return View();
        }
        public IActionResult Cena()
        {
            ViewBag.Cenas = _cenas.GellAllProducts();
            return View();
        }
        public IActionResult Snack ()
        {
            ViewBag.Snacks = _snacks.GellAllProducts();
            return View();
        }
        public IActionResult Utiles() 
        {
            ViewBag.Utiles = _utiles.GellAllProducts();
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Access");
        }
    }
}