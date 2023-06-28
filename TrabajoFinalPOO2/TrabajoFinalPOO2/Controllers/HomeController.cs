using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoFinal.Servicios;

namespace TrabajoFinal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IDesayuno _desayuno;
        private readonly IAlmuerzos _almuerzo;
        private readonly ICenas _cenas;
        private readonly ISnacks _snacks;
        private readonly IUtiles _utiles;
        
        public HomeController(IAlmuerzos almuerzos, IDesayuno desayuno, ICenas cenas, ISnacks snacks, IUtiles utiles)
        {
            _almuerzo = almuerzos;
            _desayuno = desayuno;
            _cenas = cenas;
            _snacks = snacks;
            _utiles = utiles;
        }
        [Route("TrabajoFinal/Catalogo")]
        public IActionResult Catalogo()
        {
            ClaimsPrincipal claimuser = HttpContext.User;
            ClaimsPrincipal claimimg = HttpContext.User;
            ClaimsPrincipal claimid = HttpContext.User;
            ClaimsPrincipal claimemail = HttpContext.User;
            ClaimsPrincipal claimpass = HttpContext.User;

            string nombreUsuario = "";
            string imgUsuario = "";
            string idUsuario = "";
            string emailUsuario = "";
            string passUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            if (claimimg.Identity.IsAuthenticated)
            {
                imgUsuario = claimimg.Claims.Where(c => c.Type == ClaimTypes.Actor)
                    .Select(c => c.Value).SingleOrDefault();
            }

            if (claimid.Identity.IsAuthenticated)
            {
                idUsuario = claimid.Claims.Where(c => c.Type == ClaimTypes.Country)
                    .Select(c => c.Value).SingleOrDefault();
            }

            if (claimemail.Identity.IsAuthenticated)
            {
                emailUsuario = claimemail.Claims.Where(c => c.Type == ClaimTypes.Email)
                    .Select(c => c.Value).SingleOrDefault();
            }

            if (claimpass.Identity.IsAuthenticated)
            {
                passUsuario = claimpass.Claims.Where(c => c.Type == ClaimTypes.Anonymous)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;
            ViewData["imgUsuario"] = imgUsuario;
            ViewData["idUsuario"] = idUsuario;
            ViewData["emailUsuario"] = emailUsuario;
            ViewData["passUsuario"] = passUsuario;

            ViewBag.Desayunos = _desayuno.GellAllProducts();
            ViewBag.Almuerzos = _almuerzo.GellAllProducts();
            ViewBag.Cenas = _cenas.GellAllProducts();
            ViewBag.Snacks = _snacks.GellAllProducts();
            ViewBag.Utiles = _utiles.GellAllProducts();
            return View();
        }
        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}