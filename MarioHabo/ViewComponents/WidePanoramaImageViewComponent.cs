﻿using MarioHabo.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MarioHabo.ViewComponents
{
    public class WidePanoramaImageViewComponent : ViewComponent
    {
        public WidePanoramaImageModel Model { get; set; }
        public async Task<IViewComponentResult> InvokeAsync(WidePanoramaImageModel componentmodel)
        {
            if(componentmodel is null)
            {
                Console.WriteLine($"{nameof(componentmodel)} is NULL!!");
            }
            Model = this.ViewBag.PanoModel;
            return View(Model);
        }

    }
}
