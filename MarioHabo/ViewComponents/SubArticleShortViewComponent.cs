using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.ViewComponents
{
    public class SubArticleShortViewComponent : ViewComponent
    {
        private SubArticleShortModel _model;
        public SubArticleShortViewComponent() { }

        public async Task<IViewComponentResult> InvokeAsync(string component, SubArticleShortModel model)
        {
            this._model = model;
            return View(model);
        }

    }
}
