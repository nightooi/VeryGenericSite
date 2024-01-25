using Microsoft.AspNetCore.Mvc;
using MarioHabo.Models;
namespace MarioHabo.ViewComponents
{
    [ViewComponent(Name = "WideVideoPlayer")]
    public class WideVideoPlayerViewComponent : ViewComponent
    {
        private VideoPlayerModel model;
        public WideVideoPlayerViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(string rando, VideoPlayerModel models)
        {
            this.model = models;
            return View(model);
        }
    }
}
