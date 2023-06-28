using Microsoft.AspNetCore.Mvc;

namespace TrabajoFinal.Controllers
{
    public class TrabajoFinalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("TrabajoFinal/Nosotros")]
        public IActionResult Nosotros() 
        { 
            return View(); 
        }
        [Route("TrabajoFinal/Contactanos")]
        public IActionResult Contactanos()
        {
            return View();
        }
    }
}
