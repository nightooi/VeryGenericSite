using Microsoft.AspNetCore.Mvc;

using VeryGenericSite.Models;

namespace VeryGenericSite.ViewComponents
{
    public class SubArticleShortViewComponent : ViewComponent
    {
        public SubArticleShortViewComponent() { }

        public async Task<IViewComponentResult> InvokeAsync(string component, SubArticleShortModel model)
        {
            return View(model);
        }

    }
}
