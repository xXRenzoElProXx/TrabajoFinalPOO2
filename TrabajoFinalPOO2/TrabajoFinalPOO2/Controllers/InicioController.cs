using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoFinal.Models;
using TrabajoFinal.Servicios.Contrato;

namespace TrabajoFinal.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioServicio;
        public InicioController(IUsuarioService usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        [Route("Usuario/SignUp")]
        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        [Route("Usuario/SignUp")]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Clave = modelo.Clave;
            modelo.Imagen = "https://cdn-icons-png.flaticon.com/512/3135/3135768.png";
            Usuario usuario_creado = await _usuarioServicio.SaveUsuario(modelo);

            if (usuario_creado.IdUsuario > 0)
                return RedirectToAction("IniciarSesion", "Inicio");

            ViewData["Mensaje"] = "No se pudo crear el usuario";
            return View();
        }
        [Route("Usuario/Login")]
        public IActionResult IniciarSesion()
        {
            return View();
        }
        [HttpPost]
        [Route("Usuario/Login")]
        public async Task<IActionResult> IniciarSesion(string correo, string clave)
        {
            Usuario usuario_encontrado = await _usuarioServicio.GetUsuario(correo, clave);

            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";
                return View();
            }

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario),
                new Claim(ClaimTypes.Actor, usuario_encontrado.Imagen),
                new Claim(ClaimTypes.Country, usuario_encontrado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Email, usuario_encontrado.Correo),
                new Claim(ClaimTypes.Anonymous, usuario_encontrado.Clave),
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("Catalogo", "Home");
        }
        [Route("Inicio/EditarPerfil/{codigo}")]
        public IActionResult EditarPerfil(int codigo)
        {
            ClaimsPrincipal claimimg = HttpContext.User;
            ClaimsPrincipal claimid = HttpContext.User;
            string idUsuario = "";
            string imgUsuario = "";

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
            ViewData["idUsuario"] = idUsuario;
            ViewData["imgUsuario"] = imgUsuario;

            return View(_usuarioServicio.edit(codigo));
        }
        public IActionResult editarPerfilP(Usuario obj)
        {
            _usuarioServicio.editDetails(obj);
            return RedirectToAction("Catalogo", "Home");
        }
        [Route("Inicio/CambiarPass/{id}")]
        public IActionResult CambiarPass(int id)
        {
            ClaimsPrincipal claimimg = HttpContext.User;

            string imgUsuario = "";

            if (claimimg.Identity.IsAuthenticated)
            {
                imgUsuario = claimimg.Claims.Where(c => c.Type == ClaimTypes.Actor)
                    .Select(c => c.Value).SingleOrDefault();
            }
            ViewData["imgUsuario"] = imgUsuario;

            return View(_usuarioServicio.changeP(id));
        }
        public IActionResult cambiarPassP(Usuario obj)
        {
            _usuarioServicio.cambiarPass(obj);
            return RedirectToAction("Catalogo", "Home");
        }
    }
}