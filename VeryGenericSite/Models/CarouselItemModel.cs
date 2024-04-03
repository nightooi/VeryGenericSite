namespace VeryGenericSite.Models
{
    public class CarouselItemModel
    {
        //number of items inside curre dir
        public int number;
        //OverArching Header for item
        public string Header { get; set; }

        //path for specific img
        public string[] ImgPath { get; set; }

        ///text connected to certain img, first internal array tells which img is connected the text is supposed to be connected to
        ///the second hold info on which text inside the textmodel array is to be connected to that img, ex:
        ///     index: 1 [0],[1] --> 0 is index of img inside ImgPath that is to have the text, that is on the position of text insdide carouselmodel that the img will have.
        public int[,] ImgSpecificText;
        public CarouselItemTextModel[] TextModel { get; set; }
    }
}
