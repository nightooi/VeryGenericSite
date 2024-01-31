using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Collections;
using System.Collections.Generic;
namespace MarioHabo.Models
{
    //Just a collection, don't expect all positions in collection to be filled, im not resizing this trash.
    public class ArticleIntroductoryModel : ICollection<ArticleModelEnumerated>, IEnumerator<ArticleModelEnumerated>, IEnumerable<ArticleModelEnumerated>
    { readonly static private int _TotalArticles = 0; private bool disposedValue;
        public int TotalAritcles { get { return _TotalArticles; } }
        private ArticleModelEnumerated[]? Article { get; set; }
        private int Index { get; set; } = -1;
        public int Count => Article.Length;
        public bool IsReadOnly => true;
        public ArticleModelEnumerated Current => Article [Index];
        object IEnumerator.Current => Article[Index];
        public ArticleIntroductoryModel(ArticleModelEnumerated[]? artDef)
        {
            Article = artDef;
            while (this.MoveNext()) ;
        }
        public ArticleIntroductoryModel(string imgPath, string[] article)
        {
            if (this.Article == null) this.Article = new ArticleModelEnumerated[0];
            Article.Append(new ArticleModelEnumerated(imgPath, article));
            foreach(var i in this)
            {
               i.RightBound = JustifyLeft();
            }

        }
        private bool JustifyLeft()
        {
            if ((Index % 2) == 0) return true;
            Console.WriteLine(Index +" :::Index Justify At ArticleIntro");
            return false;
        }
        public void Add(ArticleModelEnumerated item)
        {
            this.Article.Append(item);
        }
        public void Clear()
        {
            for (int i = 0; i < Article.Length; i++)
            {
                Article[i].Clear();
                Article[i].Dispose();
            }
            Article = null;
        }
        public bool Contains(ArticleModelEnumerated item)
        {
            for(int i=0; i< Article.Length; i++)
            {
                if (Article[i] == item) return true;
            };
            return false;
        }
        public void CopyTo(ArticleModelEnumerated[] array, int arrayIndex)
        {
            int k = 0;
            for (int i = arrayIndex; i < Article.Length; i++)
            {
                array[k] = Article[i];
                k++;
            }
        }
        public bool Remove(ArticleModelEnumerated item)
        {
            for (int i = 0; i < Article.Length; i++)
            {
                if (!Article[i].Equals(item)) return false;
                if (Article[i] == item)
                {
                    Article[i].Dispose();
                    int f = i;
                    for(int k = f;  i <  Article.Length-1; k++)
                    {
                        Article[f] = Article[k+1];
                        f++;
                    } 
                 return true;
                }
            }
            return false;
        }
        public IEnumerator<ArticleModelEnumerated> GetEnumerator()
        {
            return ((IEnumerable<ArticleModelEnumerated>)Article).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Article.GetEnumerator();
        }
        public bool MoveNext()
        {
            Index++;
            if (Index < this.Article.Length)
            {
                this.Current.RightBound = JustifyLeft();
                return true;
            }
            return false;

        }
        public void Reset()
        {
            Index = 0;
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
        
    }
}







