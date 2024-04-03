using VeryGenericSite.TagHelpers;

using Microsoft.AspNetCore.Mvc.RazorPages;

using System.Collections;

namespace VeryGenericSite.Models
{
    /// <summary>
    /// ClientResultion is 1280x720 base
    /// </summary>
    public class BackgroundOverlayVideoPlayerModel : PageModel, IEnumerable<VideoModel>
    {
        public VideoModel[]? Video { get; set; }
        public string? WaterMark { get; set; }

        public BackgroundOverlayVideoPlayerModel(IEnumerable<string>? videoPaths, string? waterMark)
        {
            if (videoPaths is not null)
            {
                Video = new VideoModel[videoPaths.Count()];
                int k = 0;
                foreach (var i in videoPaths)
                {
                    Video[k] = new VideoModel(i, null, null);
                    k++;
                }
            }
            if (waterMark is not null)
            {
                WaterMark = waterMark;
            }
        }
        public BackgroundOverlayVideoPlayerModel(BackgroundOverlayVideoPlayerModel model)
        {
            Video = model.Video;
            WaterMark = model.WaterMark;
        }
        public IEnumerator<VideoModel> GetEnumerator()
        {
            return ((IEnumerable<VideoModel>)Video!).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Video?.GetEnumerator();
        }

        public void OnGet()
        {

        }

    }
}
