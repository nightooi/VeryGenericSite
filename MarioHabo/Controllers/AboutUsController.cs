using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
