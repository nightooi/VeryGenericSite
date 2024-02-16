using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MarioHabo.ViewComponents
{
    public class WidePanoramaImageViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync(string componentName, WidePanoramaImageModel? componentmodel)
        {
            return View(componentmodel);
        }

    }
}
