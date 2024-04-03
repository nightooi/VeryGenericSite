using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using VeryGenericSite.Models;

namespace VeryGenericSite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public void VisitationRequest(ContactFormModel? value)
        {

        }
    }
}
