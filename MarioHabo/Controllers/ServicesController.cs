using Microsoft.AspNetCore.Mvc;
using MarioHabo.Models;
namespace MarioHabo.Controllers
{
    public class ServicesController : Controller
    {
        ///
        ///#TODO add a property to carouselItemModel to distinguish the model objects from eachother and add a extra readonly field to 
        ///         set the carouselname in cases where we have multiple carousels on the same view. Also i need to add more logic to the 
        ///         carousel text-html in order to be able to insert more subheaders and paragraphs. 
        ///         think ill just add a internal class to distinguish that.
        ///     
        public IActionResult Index()
        {
            CarouselItemModel model = new CarouselItemModel
            {
                ImgSpecificText = new int[,] { { 0, 1 },{ 2, 2 }, { 1, 0} },
                Header = "MainHeader",
                ImgPath = Directory.GetFiles("wwwroot/assets/Images"),
                number = 2,
                TextModel = new CarouselItemTextModel[] {
                    new CarouselItemTextModel { SubHeader = "Subheader", Text = "Text" },
                    new CarouselItemTextModel { SubHeader = "Second Subheader", Text = "Text2" },
                    new CarouselItemTextModel { SubHeader = "Third Subheader", Text = "Text3" }
                }
            };
            var it = 0;
            foreach(var item in model.ImgPath)
            {
                var rep = item.Replace("wwwroot", "~");
                model.ImgPath[it] = rep;
                Console.WriteLine(model.ImgPath[it]);
                it++;
            }

            
            return View(model);
        }
    }
}
