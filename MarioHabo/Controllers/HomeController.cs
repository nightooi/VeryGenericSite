﻿using Elfie.Serialization;

using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.ObjectPool;

using NuGet.ContentModel;

using System.Diagnostics;

namespace MarioHabo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var a = new BackgroundOverlayVideoPlayerModel(new string[] 
            { "../assets/Images/Videos/Construction Site - 42923.mp4",
              "../assets/Images/Videos/pexels-tima-miroshnichenko-6473946.mp4",
              "../assets/Images/Videos/pexels-tima-miroshnichenko-6474141.mp4"}.AsEnumerable(), "MBHAB");
            ViewData["videoModel"] = a;
            return View();
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