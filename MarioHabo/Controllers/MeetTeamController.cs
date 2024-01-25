using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;

namespace MarioHabo.Controllers
{
    public class MeetTeamController : Controller
    {
        public IActionResult Index()
        {
            var s = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\wwwroot\\assets\\Images", "*.jpg");
            ArticleModel[] mos = Populate(s).ToArray();
            ArticleIntroductoryModel model = new ArticleIntroductoryModel(mos);
            string[] some = this.PopulateString(s, 5).ToArray();
            SubArticleShortModel mod = new SubArticleShortModel(
                new[] { "SomeHeader", "Lorem ipsum dolor sit amet,orem ipsum dolor " +
                "sit amet,orem ipsum dolor sit amet,orem ipsum dolor sit amet,orem" +
                " ipsumorem ipsum dolor sit amet,orem ipsum dolor sit amet,orem" +
                " ipsum dolor sit amet,orem ipsum dolor sit amet,orem ipsum dolor" +
                " sit amet,Lorem ipsum dolor sit amet,orem ipsum dolor sit amet,orem" +
                " ipsum dolor sit amet,orem ipsum dolor sit amet,orem ipsum dolor" +
                " sit amet,Lorem ipsum dolor sit amet,orem ipsum dolor sit amet,orem" +
                " ipsum dolor sit amet,orem ipsum dolor sit amet,orem ipsum dolor" +
                " sit amet," },
                some,
                new[] { new SubArticleShortModel.ImgCaptions(1, "Lorem ipsium dolor"," consectetur adipiscin elit, sed do eiusmod tempor" ),
                    new SubArticleShortModel.ImgCaptions(2, "Lorem ipsium", " consectetur adipiscin elit," +
                    " sed do eiusmod tempor consectetur adipiscin elit, sed do eiusmod temporonsectetur " +
                    "adipiscin elit, sed do eiusmod tempor consectetur adipiscin elit, sed do eiusmod " +
                    "temporonsectetur adipiscin elit, sed do eiusmod tempor consectetur adipiscin " +
                    "elit, sed do eiusmod temporonsectetur adipiscin elit, sed do eiusmod tempor " +
                    "consectetur adipiscin elit, sed do eiusmod temporonsectetur adipiscin elit, " +
                    "sed do eiusmod tempor consectetur adipiscin elit, sed do eiusmod temporonsectetur " +
                    "adipiscin elit, sed do eiusmod tem"),
                new SubArticleShortModel.ImgCaptions(3,"Lorem Ipsum dolor sit amet",
                "Lorem ipsum dolor sit amet," +
                " consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore" +
                " et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation" +
                " ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure" +
                " dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat" +
                " nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in" +
                " culpa qui officia deserunt mollit anim id est laborum.")});


            MeetTeamCompositeModel modelH = new MeetTeamCompositeModel
            {
                AricleIntro = model,
                SubShort = mod
            };

            ViewBag.SubShortMod = mod;

            Console.WriteLine(mod.ImgCaption[0].ImgIndex +" ::ImgIndex");
            Console.WriteLine(mod.ImgCaption[1].ImgIndex +" ::ImgIndex");

            Console.WriteLine(mod.ImgPaths.Length);
            Console.WriteLine(modelH.SubShort.Article[0]);


            return View(modelH);
        }


        private IEnumerable<ArticleModel> Populate(string[] a)
        {
            foreach (var i in a)
            {
                string k = i.Replace(Directory.GetCurrentDirectory() + "\\wwwroot", "..");
                    yield return new ArticleModel(k,
                        new string[]
                                    {
                                        "Header", "Subheader"," Lorem ipsum dolor sit amet," +
                                         " consectetur adipiscin elit, sed do eiusmod tempor"+
                                        " incididunt ut labore t dolore magna aliqua. Ut enim" +
                                        " ad minim veniam, quisnostrud exercitation ullamco" + 
                                        " laboris nisi ut aliquip ex ea commodo consequat." +
                                        " Duis aute irure dolor in reprehenderit in voluptate" +
                                        " velit esse cillum dolore eu fugiat nulla pariatur." +
                                        " Excepteur sint occaecat cupidatat non proident," +
                                        " sunt in culpa qui officia deserunt mollit anim id est laborum."
                                    });

                }
            
        }

        private IEnumerable<string> PopulateString(string[] s, int imgAmount)


        {

            string[] copy = new string[imgAmount]; 
            Array.Copy(s, copy, imgAmount);
            foreach(var i in copy)
            {
                string k = i.Replace(Directory.GetCurrentDirectory() + "\\wwwroot", "..");
                yield return k;
            }
        }
    }
}


















