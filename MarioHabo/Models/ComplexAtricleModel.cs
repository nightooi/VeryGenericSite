namespace MarioHabo.Models
{
    /// <summary>
    /// No default Initialization.
    /// Passed null values are Allowed they impact the view
    /// </summary>
    public class ComplexAtricleModel : SimpleArticleModel
    {
        public ComplexAtricleModel(string? Header, string? SubHeader, string? Article) : base(Header, SubHeader, Article)
        {

        }

        public int? Images { get; set; }
        public int? SubHeaders { get; set; }
        public int? Articles { get; set; }
        public string[]? ImagePaths { get; set; }


    }
}
