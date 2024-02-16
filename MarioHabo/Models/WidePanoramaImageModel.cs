using Microsoft.Extensions.ObjectPool;

using System;
using Microsoft;

using System.Security.Permissions;

namespace MarioHabo.Models
{
    public class WidePanoramaImageModel
    {
        public string[] RequestImages { get; set; }
        public SingleImageArticleBundleModel[] ArticleBundle { get; set; }
        public SingleImageArticleBundleModel[] OnHoverArticleBundle { get; set; }
        public string WaterMark { get; set; }
        
        public  WidePanoramaImageModel(WidePanoramaImageModel model)
        {
            this.RequestImages = model.RequestImages;
            this.WaterMark = model.WaterMark;
            this.ArticleBundle = model.ArticleBundle;
            this.OnHoverArticleBundle = model.OnHoverArticleBundle;
        }

        public WidePanoramaImageModel(string[] requestImages, string waterMark, 
            SingleImageArticleBundleModel[] MainArticle, SingleImageArticleBundleModel[] OnHoverArticleBundle)
        {
            this.Sort(MainArticle);
            this.Sort(OnHoverArticleBundle);
            this.ArticleBundle = MainArticle; 
            this.OnHoverArticleBundle = OnHoverArticleBundle;
            this.WaterMark = waterMark;
            this.RequestImages = requestImages;
        }

        void Sort(SingleImageArticleBundleModel[]? array)
        {
            if (array is not null) Array.Sort(array);
        }
    }
}
