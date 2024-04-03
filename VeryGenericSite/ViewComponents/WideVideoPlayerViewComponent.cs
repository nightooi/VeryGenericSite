using Microsoft.AspNetCore.Mvc;

using VeryGenericSite.Models;
namespace VeryGenericSite.ViewComponents
{
    [ViewComponent(Name = "WideVideoPlayer")]
    public class WideVideoPlayerViewComponent : ViewComponent
    {
        private BackgroundOverlayVideoPlayerModel model;
        public WideVideoPlayerViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(string rando, BackgroundOverlayVideoPlayerModel models)
        {
            model = models;
            return View(model);
        }
    }
}
