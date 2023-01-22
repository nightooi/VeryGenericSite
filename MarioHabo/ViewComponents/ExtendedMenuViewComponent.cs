using Microsoft.AspNetCore.Mvc;
namespace MarioHabo.ViewComponents
{
    [ViewComponent(Name ="ExtendedMenu")]
    public class ExtendedMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string rando)
        {
            return View();
        }
    }
}
