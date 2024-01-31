using Microsoft.AspNetCore.Mvc;
using MarioHabo.Models;
namespace MarioHabo.ViewComponents
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
            this.model = models;
            return View(model);
        }
    }
}
