namespace MarioHabo.Models
{
    public class WideInfoPane
    {
        public string? Header { get; set; }

        public InfoPane[]? Info { get; set; }

        public class InfoPane
        {
            public string[]? SubHeader { get; set; }
            public string[]? Text { get; set; }

            public string[]? ImgPath { get; set; }

            public InfoPane(string[] subheader, string[] text, string[] imgPath)
            {
                this.SubHeader = subheader;
                this.Text = text;
                setImgPath(imgPath);
            }

            private void setImgPath(string[]? items)
            {
                try
                {
                    if(items?.Length > 2)
                    {
                        throw new Exception("TOO MANY IMGES INSIDE IMGPATH ARRAY");
                    }
                    else
                    {
                        this.ImgPath = new string[2];
                        this.ImgPath[0] = items[0] ??= "";
                        this.ImgPath[1] = items[1] ??= "";
                    } 

                } catch (Exception exc)
                {
                    this.ImgPath = new string[]{ "NULLNULLNULLNULL" + " \n"+ exc.Message , "NULLNULLNULLNULL" + "\n" + exc.StackTrace };
                }
            }
        }
    }
}
