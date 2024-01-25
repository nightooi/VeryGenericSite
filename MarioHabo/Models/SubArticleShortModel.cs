using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.Models
{
    public class SubArticleShortModel
    {
        public string[]? Article { get; set; }
        public string[]? ImgPaths { get; set; }
        public ImgCaptions[]? ImgCaption { get; set; } 

        public SubArticleShortModel(string[]? Article, string[]? ImgPaths, ImgCaptions[]? ImgCaption)
        {
            this.Article = Article;
            this.ImgCaption = ImgCaption;
            this.ImgPaths = ImgPaths;
            if(!(this.ImgCaption == null))
            {
                Array.Sort<ImgCaptions>(this.ImgCaption);

            }
        }

        public class ImgCaptions : IComparable<ImgCaptions>
        {
            public int? ImgIndex { get; set; }
            public string? ImgCaption { get; set; }
            public string? SubArticle { get; set; }
            public ImgCaptions(int? ImgIndex, string? ImgCaption, string? Subarticle)
            {
                this.ImgCaption = ImgCaption;
                this.ImgIndex = ImgIndex;
                this.SubArticle = Subarticle;
            }
            //compares by IndexValue
            int IComparable<ImgCaptions>.CompareTo(ImgCaptions? other)
            {
                if (other == null && this != null) return 1;
                if (this == null && other != null) return 0;
                if (this.ImgIndex >= (other.ImgIndex ?? 0)) return 1;
                return 0;
            }
        }
    }
}
