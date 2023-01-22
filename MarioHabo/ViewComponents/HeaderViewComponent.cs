using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.ViewComponents
{

    [ViewComponent(Name = "Header")]
    public class HeaderComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            return View("Default");
        }
    }
}
