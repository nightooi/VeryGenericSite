namespace VeryGenericSite.Models
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
                SubHeader = subheader;
                Text = text;
                setImgPath(imgPath);
            }

            private void setImgPath(string[]? items)
            {
                try
                {
                    if (items?.Length > 2)
                    {
                        throw new Exception("TOO MANY IMGES INSIDE IMGPATH ARRAY");
                    }
                    else
                    {
                        ImgPath = new string[2];
                        ImgPath[0] = items[0] ??= "";
                        ImgPath[1] = items[1] ??= "";
                    }

                }
                catch (Exception exc)
                {
                    ImgPath = new string[] { "NULLNULLNULLNULL" + " \n" + exc.Message, "NULLNULLNULLNULL" + "\n" + exc.StackTrace };
                }
            }
        }
    }
}
