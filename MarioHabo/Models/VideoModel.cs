namespace MarioHabo.Models
{
    /// <summary>
    /// VideoPath base init strign: "...Oopsie"
    /// WidthHeight base init 1280x720
    /// </summary>
    public class VideoModel
    {
        public string? VideoPath { get; set; } = "...Oopsie";
        public int? Width { get; set; } = 1280;
        public int? Height { get; set; } = 720;
        public VideoModel(string? videoPath, int? width, int? height)
        {
            this.VideoPath = videoPath;
            this.Width = width;
            this.Height = height;
        }
    }
}
