using Microsoft.AspNetCore.Mvc;
namespace VeryGenericSite.ViewComponents
{
    [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string rando)
        {
            return View();
        }
    }
}
