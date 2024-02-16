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

        public SimpleArticleModel(string? Header, string? SubHeader, string? Article)
        {
            this.Header = Header;
            this.SubHeader = SubHeader;
            this.Article =  Article;
        }
    }
}
