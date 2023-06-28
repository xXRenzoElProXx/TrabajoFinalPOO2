using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TrabajoFinal.Models;
using TrabajoFinal.Servicios;

namespace TrabajoFinal.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        private readonly IDesayuno _desayuno;
        private readonly IAlmuerzos _almuerzo;
        private readonly ICenas _cenas;
        private readonly ISnacks _snacks;
        private readonly IUtiles _utiles;
        public ProductoController(IAlmuerzos almuerzos, IDesayuno desayuno, ICenas cenas, ISnacks snacks, IUtiles utiles, ITemporalVenta temporalVenta)
        {
            _almuerzo = almuerzos;
            _desayuno = desayuno;
            _cenas = cenas;
            _snacks = snacks;
            _utiles = utiles;
            _temporalVenta = temporalVenta;
       }
        [Route("Producto/ComprarD/{codigo}")]
        public IActionResult ComprarD(string codigo)
        {
            TemporalVenta objCarro = new TemporalVenta();

            if (_temporalVenta.Exists(objCarro.codigo))
            {
                TempData["Message"] = "El producto ya está en el carrito.";
            }
            var objRecibido = _desayuno.GetProducto(codigo);
            return View(objRecibido);
        }
        public IActionResult filtrarPrecio(int precio1, int precio2) {
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

            ViewBag.FiltrarPrecioA = _almuerzo.filtrarPrecio(precio1, precio2);
            ViewBag.FiltrarPrecioD = _desayuno.filtrarPrecio(precio1, precio2);
            ViewBag.FiltrarPrecioC = _cenas.filtrarPrecio(precio1, precio2);
            ViewBag.FiltrarPrecioU = _utiles.filtrarPrecio(precio1, precio2);
            ViewBag.FiltrarPrecioS= _snacks.filtrarPrecio(precio1, precio2);

            return View();
        }
        [Route("Producto/ComprarA/{codigo}")]
        public IActionResult ComprarA(string codigo)
        {
            TemporalVenta objCarro = new TemporalVenta();

            if (_temporalVenta.Exists(objCarro.codigo))
            {
                TempData["Message"] = "El producto ya está en el carrito.";
            }
            var objRecibido = _almuerzo.GetProducto(codigo);
            return View(objRecibido);
        }
        [Route("Producto/ComprarC/{codigo}")]
        public IActionResult ComprarC(string codigo)
        {
            TemporalVenta objCarro = new TemporalVenta();

            if (_temporalVenta.Exists(objCarro.codigo))
            {
                TempData["Message"] = "El producto ya está en el carrito.";
            }
            
            var objRecibido = _cenas.GetProducto(codigo);
            return View(objRecibido);
        }
        [Route("Producto/ComprarS/{codigo}")]
        public IActionResult ComprarS(string codigo)
        {
            TemporalVenta objCarro = new TemporalVenta();

            if (_temporalVenta.Exists(objCarro.codigo))
            {
                TempData["Message"] = "El producto ya está en el carrito.";
            }
            var objRecibido = _snacks.GetProducto(codigo);
            return View(objRecibido);
        }
        [Route("Producto/ComprarU/{codigo}")]
        public IActionResult ComprarU(string codigo)
        {
            TemporalVenta objCarro = new TemporalVenta();

            if (_temporalVenta.Exists(objCarro.codigo))
            {
                TempData["Message"] = "El producto ya está en el carrito.";
            }
            var objRecibido = _utiles.GetProducto(codigo);
            return View(objRecibido);
        }

        //DESAYUNO
        public IActionResult NuevoD()
        {
            return View();
        }
        public IActionResult GrabarD(TbDesayuno obj)
        {
            _desayuno.add(obj);
            return RedirectToAction("Desayuno", "Admin");
        }
        [Route("Producto/EliminarD/{codigo}")]
        public IActionResult EliminarD(string codigo)
        {
            _desayuno.remove(codigo);
            return RedirectToAction("Desayuno", "Admin");
        }
        [Route("Producto/EditarD/{codigo}")]
        public IActionResult EditarD(string codigo)
        {
            return View(_desayuno.edit(codigo));
        }
        public IActionResult editarProductoD (TbDesayuno obj)
        {
            _desayuno.editDetails(obj);
            return RedirectToAction("Desayuno", "Admin");
        }
        //ALMUERZO
        public IActionResult NuevoA()
        {
            return View();
        }
        public IActionResult GrabarA(TbAlmuerzo obj)
        {
            _almuerzo.add(obj);
            return RedirectToAction("Almuerzo", "Admin");
        }
        [Route("Producto/EliminarA/{codigo}")]
        public IActionResult EliminarA(string codigo)
        {
            _almuerzo.remove(codigo);
            return RedirectToAction("Almuerzo", "Admin");
        }
        [Route("Producto/EditarA/{codigo}")]
        public IActionResult EditarA(string codigo)
        {
            return View(_almuerzo.edit(codigo));
        }
        public IActionResult editarProductoA(TbAlmuerzo obj)
        {
            _almuerzo.editDetails(obj);
            return RedirectToAction("Almuerzo", "Admin");
        }
        //CENA
        public IActionResult NuevoC()
        {
            return View();
        }
        public IActionResult GrabarC(TbCena obj)
        {
            _cenas.add(obj);
            return RedirectToAction("Cena", "Admin");
        }
        [Route("Producto/EliminarC/{codigo}")]
        public IActionResult EliminarC(string codigo)
        {
            _cenas.remove(codigo);
            return RedirectToAction("Cena", "Admin");
        }
        [Route("Producto/EditarC/{codigo}")]
        public IActionResult EditarC(string codigo)
        {
            return View(_cenas.edit(codigo));
        }
        public IActionResult editarProductoC(TbCena obj)
        {
            _cenas.editDetails(obj);
            return RedirectToAction("Cena", "Admin");
        }
        //SNACK
        public IActionResult NuevoS()
        {
            return View();
        }
        public IActionResult GrabarS(TbSnack obj)
        {
            _snacks.add(obj);
            return RedirectToAction("Snack", "Admin");
        }
        [Route("Producto/EliminarS/{codigo}")]
        public IActionResult EliminarS(string codigo)
        {
            _snacks.remove(codigo);
            return RedirectToAction("Snack", "Admin");
        }
        [Route("Producto/EditarS/{codigo}")]
        public IActionResult EditarS(string codigo)
        {
            return View(_snacks.edit(codigo));
        }
        public IActionResult editarProductoS(TbSnack obj)
        {
            _snacks.editDetails(obj);
            return RedirectToAction("Snack", "Admin");
        }
        //UTILES
        public IActionResult NuevoU()
        {
            return View();
        }
        public IActionResult GrabarU(TbUtile obj)
        {
            _utiles.add(obj);
            return RedirectToAction("Utiles", "Admin");
        }
        [Route("Producto/EliminarU/{codigo}")]
        public IActionResult EliminarU(string codigo)
        {
            _utiles.remove(codigo);
            return RedirectToAction("Utiles", "Admin");
        }
        [Route("Producto/EditarU/{codigo}")]
        public IActionResult EditarU(string codigo)
        {
            return View(_utiles.edit(codigo));
        }
        public IActionResult editarProductoU(TbUtile obj)
        {
            _utiles.editDetails(obj);
            return RedirectToAction("Utiles", "Admin");
        }
    }
}