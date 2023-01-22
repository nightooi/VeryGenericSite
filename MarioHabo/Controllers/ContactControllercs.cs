using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.Controllers
{
    public class ContactControllercs : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
