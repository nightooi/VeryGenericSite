using Microsoft.AspNetCore.Mvc;
namespace VeryGenericSite.ViewComponents
{
    [ViewComponent(Name = "ExtendedMenu")]
    public class ExtendedMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string rando)
        {
            return View();
        }
    }
}
