/*using Humanizer;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

using System.Reflection;
using System.Text;

namespace MarioHabo.TagHelpers
{
    //p:somecss:somecss;>div:somecss:somecss;>p:somecss;03#:somecss>#content
    //d>p>#something>a
    //somecss,somecss;somecss;somecsssomecss;
    public static class HelperTagFactory<T> where T : TagHelper
    {                                                               //if true, applies string to tag to iterated Tag
        public static T Factory(string builder,T taghelper)
        {
            List<TagBuilder> b = new();
            string[] split = builder.Split(';');
            foreach (var tag in builder)
            {
                if (css.StartsWith(tag))
                {
                   b.Add() 
                }
            }
            
            return htmlTag;
        }

       
    }
}*/
