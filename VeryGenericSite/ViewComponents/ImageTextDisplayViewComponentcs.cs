using Microsoft.AspNetCore.Mvc;

using VeryGenericSite.Models;
namespace VeryGenericSite.ViewComponents
{
    [ViewComponent(Name = "ImageTextDisplay")]
    public class ImageTextDisplayViewComponentcs : ViewComponent
    {
        private readonly CarouselItemModel[] _models;

        public ImageTextDisplayViewComponentcs()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(string name, CarouselItemModel models)
        {

            var item = models;
            //#error VIEW FUNCTIONCALL IN INVOKEASYNC INSIDE ImageTextDisplayViewComponentcs IS SET TO "DEFAULT.CSHTML" DON'T EXPECT THIS COMPONENT TO WORK.
            return View(item);
        }
    }
}
