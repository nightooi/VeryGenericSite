using Microsoft.AspNetCore.Mvc;

namespace VeryGenericSite.Controllers
{
    public class ReferencesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
