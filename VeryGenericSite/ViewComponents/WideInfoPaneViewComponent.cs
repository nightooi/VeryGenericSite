using Microsoft.AspNetCore.Mvc;

using VeryGenericSite.Models;
namespace VeryGenericSite.ViewComponents
{
    [ViewComponent(Name = "WideInfoPane")]
    public class WideInfoPaneViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string name, WideInfoPane models)
        {
            var item = models;
            return View(item);
        }
    }
}
