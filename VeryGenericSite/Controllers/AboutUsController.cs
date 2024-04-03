using Microsoft.AspNetCore.Mvc;

namespace VeryGenericSite.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
