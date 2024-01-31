namespace MarioHabo.Models
{
    /// <summary>
    /// Default all fields are nullInitialized
    /// </summary>
    public class SimpleArticleModel
    {
        public string? Header { get; set; } = null;
        public string? SubHeader { get; set; } = null;

        public string? Article { get; set; } = null;
    }
}
