using Microsoft.AspNetCore.Mvc;
using TrabajoFinal.Servicios;
using TrabajoFinal.Models;
using System.Security.Claims;

namespace TrabajoFinal.Controllers
{
    public class TemporalVentaController : Controller
    {
        private readonly ITemporalVenta _temporalVenta;
        public TemporalVentaController(ITemporalVenta temporalVenta)
        {
            _temporalVenta = temporalVenta;
        }
        public IActionResult Index(string txtcodigo, string txtdescripcion, string txtprecio,string txtcantidad)
        {
            TemporalVenta objTemporal = new TemporalVenta();
            objTemporal.codigo = txtcodigo;
            objTemporal.descripcion = txtdescripcion;
            objTemporal.precio = double.Parse(txtprecio);
            objTemporal.cantidad = int.Parse(txtcantidad);
            objTemporal.total = objTemporal.precio * objTemporal.cantidad;
            if (!_temporalVenta.Exists(objTemporal.codigo))
            {
                _temporalVenta.add(objTemporal);
            }
            else
            {
                TempData["Message"] = "El producto ya está en el carrito.";
            }

            return RedirectToAction("Catalogo", "Home");
        }
        [Route("Producto/VerCarrito")]
        public IActionResult VerCarrito()
        {
            return View(_temporalVenta.GetAllTemporarySales());
        }
        [Route("Producto/Remove/{id}")]
        public IActionResult Remove(string id)
        {
            return View(_temporalVenta.RemoveProduct(id));
        }
        [Route("TemporalVenta/EditarT/{codigo}")]
        public IActionResult EditarT(string codigo)
        {
            return View(_temporalVenta.edit(codigo));
        }
        public IActionResult editarProductoT(TemporalVenta obj)
        {
            _temporalVenta.editDetails(obj);
            return RedirectToAction("VerCarrito", "TemporalVenta");
        }
        [Route("Producto/Boleta")]
        public IActionResult Pagar()
        {
            ClaimsPrincipal claimuser = HttpContext.User;

            string nombreUsuario = "";

            if (claimuser.Identity.IsAuthenticated)
            {
                nombreUsuario = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = nombreUsuario;

            TemporalVenta objTemporal = new TemporalVenta();
            return View(_temporalVenta.GetAllTemporarySales());
        }
        public IActionResult VaciarLista()
        {
            return View(_temporalVenta.VaciarLista());
        }
    }
}