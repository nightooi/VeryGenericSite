using System.Collections;
namespace MarioHabo.Models
{
    public class ArticleModelEnumerated : IEnumerable<string>, IEnumerator<string>, ICollection<string>
    {
        public bool RightBound { get; set; }
        public ArticleModelEnumerated(string imgPath, string[] Article)
        {
            this._ImgPath = imgPath;
            this._Article = Article;
        }
        readonly private string? _ImgPath = null;
        private bool disposedValue;
        public string? ImgPath { get { return _ImgPath; } }
        readonly private string[]? _Article = null;
        public string[]? Article { get { return _Article; } }
        private int Iterator { get; set; } = 0;
        public string Current => Article[Iterator];
        object IEnumerator.Current => Article[Iterator];
        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>)_Article).GetEnumerator();
        }
        readonly private int[]? _Headerlocations = null;
        public int[]? Headerlocations { get { return _Headerlocations; } }
        public int Count => ((ICollection<string>)_Article).Count;
        public bool IsReadOnly => ((ICollection<string>)_Article).IsReadOnly;
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Article.GetEnumerator();
        }
        public bool MoveNext()
        {
            this.Iterator++;
            if (this.Iterator <= this._Article.Length)
            {
                return true;
            }
            else return false;
        }
        public void Reset()
        {
            this.Iterator = 0;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ArticleIntroductoryModel()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        public void Add(string item)
        {
            ((ICollection<string>)_Article).Add(item);
        }
        public void Clear()
        {
            ((ICollection<string>)_Article).Clear();
        }
        public bool Contains(string item)
        {
            return ((ICollection<string>)_Article).Contains(item);
        }
        public void CopyTo(string[] array, int arrayIndex)
        {
            ((ICollection<string>)_Article).CopyTo(array, arrayIndex);
        }
        public bool Remove(string item)
        {
            return ((ICollection<string>)_Article).Remove(item);
        }
        public IEnumerable<string> HeaderAndSubheaderLocations()
        {
            int k = -1;
            for (int a = 0; a < this.Count; a++)
            {
                k++;
                if (this.Headerlocations[k] == a) yield return this.Article[a];
            }
        }
    }
}







