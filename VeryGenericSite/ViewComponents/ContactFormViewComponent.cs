using Microsoft.AspNetCore.Mvc;

namespace VeryGenericSite.ViewComponents
{
    public class ContactFormViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
