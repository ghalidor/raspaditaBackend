using Microsoft.AspNetCore.Mvc;

namespace raspaditaAPi.Controllers
{
    public class TransaccionesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
