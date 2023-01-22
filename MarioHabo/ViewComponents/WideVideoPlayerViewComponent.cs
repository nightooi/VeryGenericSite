using Microsoft.AspNetCore.Mvc;
using MarioHabo.Models;
namespace MarioHabo.ViewComponents
{
    [ViewComponent(Name = "WideVideoPlayer")]
    public class WideVideoPlayerViewComponent : ViewComponent
    {
        public VideoPlayerModel model;
        public WideVideoPlayerViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync(string rando, VideoPlayerModel models)
        {
            var item = models;
            return View(item);
        }
    }
}
