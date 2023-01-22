using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace MarioHabo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var imgpath = new string[] { "../assets/Images/pexels-cal-david-735319.jpg", "../assets/Images/pexels-la-miko-3615725.jpg" };
            
            WideInfoPane infopaneItems = new WideInfoPane()
            {
                Header = "This is the main WideInfoPaneHeader",
                Info = new WideInfoPane.InfoPane[] { new WideInfoPane.InfoPane(new string[]{"this is the WideInfoPane Subheader First", "this is the WideInfoPane SubheaderSecond" }, 
                new string[]{"Lorem ipsum dolor sit amet, consectetur adipiscing elit \\" +
                " Vestibulum rhoncus rhoncus nisi sit amet ornare. Suspendisse bibendum nisi nec fermentum iaculis. Suspendis", "Vestibulum rhoncus rhoncus nisi sit amet ornare. Suspendisse bibendum nisi nec fermentum iaculis. Suspendis Vestibulum rhoncus rhoncus nisi sit amet ornare. Suspendisse bibendum nisi nec fermentum iaculis. Suspendis" }, imgpath),
                    new WideInfoPane.InfoPane(new string[]{"this is the WideInfoPane Subheader Second" , "this is the WideInfoPane Subheader Third"}, new string[]{"Nam pulvinar, felis malesuada tempor euismod,","Nam pulvinar, felis malesuada tempor euismod,Nam pulvinar, felis malesuada tempor euismod,Nam pulvinar, felis malesuada tempor euismod,"  }, 
                    imgpath) }
            };
            
            ViewData["wideinfo"] = infopaneItems;

            var file = Directory.GetFiles("C:/Users/rafae/source/repos/MarioHabo/MarioHabo/wwwroot/assets/Images/Videos");
            string[] placehold = new string[file.Count()];
            var iterator = 0;
            foreach(var item in file)
            {
                placehold[iterator] = item.Replace("C:/Users/rafae/source/repos/MarioHabo/MarioHabo/wwwroot", "..");
                    iterator++;
            }

            VideoPlayerModel model = new VideoPlayerModel()
            {
                Header = "Wide Video Player Header",
                Text = "this is some text that's \\" +
                "that's gonna be inserted into the widevideoplayer text pane, it should be quite long for we will have to define \\" +
                "and test its functionality quite thouroughly. Let's hope nothing breaks cus this will be hard to fix. Nah jk \\" +
                "it's gonna be fine, you'll see. Why do I do this to myself.",
                VideoSource = placehold
                
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}