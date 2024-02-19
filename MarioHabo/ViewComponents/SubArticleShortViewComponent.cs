using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.ViewComponents
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
