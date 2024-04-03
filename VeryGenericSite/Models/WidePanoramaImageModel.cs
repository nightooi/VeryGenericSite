using Microsoft.Extensions.ObjectPool;

using System;
using Microsoft;

using System.Security.Permissions;

namespace VeryGenericSite.Models
{
    public class WidePanoramaImageModel
    {
        public string[] RequestImages { get; set; }
        public SingleImageArticleBundleModel[] ArticleBundle { get; set; }
        public SingleImageArticleBundleModel[] OnHoverArticleBundle { get; set; }
        public string WaterMark { get; set; }

        public WidePanoramaImageModel(WidePanoramaImageModel model)
        {
            RequestImages = model.RequestImages;
            WaterMark = model.WaterMark;
            ArticleBundle = model.ArticleBundle;
            OnHoverArticleBundle = model.OnHoverArticleBundle;
        }

        public WidePanoramaImageModel(string[] requestImages, string waterMark,
            SingleImageArticleBundleModel[] MainArticle, SingleImageArticleBundleModel[] OnHoverArticleBundle)
        {
            Sort(MainArticle);
            Sort(OnHoverArticleBundle);
            ArticleBundle = MainArticle;
            this.OnHoverArticleBundle = OnHoverArticleBundle;
            WaterMark = waterMark;
            RequestImages = requestImages;
        }

        void Sort(SingleImageArticleBundleModel[]? array)
        {
            if (array is not null) Array.Sort(array);
        }
    }
}
