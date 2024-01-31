using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace MarioHabo.ViewComponents
{
    public class CoveringVideo : ViewComponent
    {
        public string VideoPath { get; set; }

        public bool Cover { get; set; }

        public int[] HeightWidth { get; set; }

       public async Task<IViewComponentResult> InvokeAsync()
       {
            return View();
       }

    }
}
