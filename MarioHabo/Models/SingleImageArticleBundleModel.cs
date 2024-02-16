namespace MarioHabo.Models
{
    public class SingleImageArticleBundleModel : SimpleArticleModel, IComparable<SingleImageArticleBundleModel>
    {
        private readonly int? _imageTied;
        public int? ImageTied { 
            get
            {
                return _imageTied;
            }
            init
            {
                _imageTied = value;
            }
        }

        public SingleImageArticleBundleModel(string? Header, string? Article, string? SubHeader, int? ImageTied = 0) : base(Header, Article, SubHeader)
        {
            this.ImageTied = ImageTied;
            
        }
        //Compares by what images its tied too.

        public int CompareTo(SingleImageArticleBundleModel? other)
        {
            if (other == null) return -1;
            if (other.ImageTied < this.ImageTied) return -1;
            if (other.ImageTied == null) return -1;

            if (other.ImageTied == this.ImageTied) return 0;
            if (other.ImageTied == this.ImageTied) return 0;

            if (other.ImageTied < this.ImageTied) return -1;
            return 0;
        }
    }

}
