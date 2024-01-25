﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

using System.Diagnostics.Eventing.Reader;
using System.Text.Encodings.Web;

namespace MarioHabo.TagHelpers
{   
    //Broken Do not Use!
    [HtmlTargetElement("GSfigure", Attributes ="rightbound", ParentTag ="div", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class BSFigureTagHelper : TagHelper
    {
        [HtmlAttributeName(DictionaryAttributePrefix = "asp-for-")]
        Dictionary<string, object> AspForDict { get; set; } = new Dictionary<string, object>();
        [HtmlAttributeName(DictionaryAttributePrefix = "BSFigure")]
        Dictionary<string, object> BSFigureDict { get; set; } = new Dictionary<string, object>();

        [HtmlAttributeName("rightbound")]
        public bool? Rightbound { get; set; } = false;
        [HtmlAttributeName("hastext")]
        public bool? HasSubText { get; set; } = false;
        [HtmlAttributeName("index")]
        public int? Index{ get; set; }
        [HtmlAttributeName("subtext")]
        public string? subText { get; set; }
        [HtmlAttributeName("src")]
        public string[]? src { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(this.Index == null)
            {
                throw new NullReferenceException(nameof(this.Index));
            }
            if(this.subText == null)
            {
                throw new NullReferenceException(nameof(this.subText));
            }
            if(this.Rightbound == null)
            {
                throw new NullReferenceException(nameof(this.subText));
            }
            if(this.Rightbound ?? false)
            {
               this.BuildTag(ref output);
            }
            else
            {
               // this.BuildTag(ref output);
            }
        }

        private void SetSubText(ref TagBuilder subtext, ref TagHelperOutput outputp, string roundedDirection)
        {
            if(this.HasSubText ?? false)
            {
                subtext.Attributes.Add("class", "figure-caption text-center bg-white "+roundedDirection);
                outputp.Content.AppendHtml(subtext.RenderStartTag());                    
                outputp.Content.AppendHtml(this.subText);                                
                outputp.Content.AppendHtml(subtext.RenderEndTag());                      
            }
        }
        /// <summary>
        /// TODO: Redefine the entire taghelper, the set above will have to dependent on context
        ///         entire logic needs to be redone, for now this will have to do.
        /// </summary>
        /// <param name="subtext"></param>
        /// <param name="outputp"></param>
        /// <param name="a"></param>
        private void BuildTag(ref TagHelperOutput outputp)
        {
            TagBuilder subtext = new TagBuilder("figcaption");
            if(this.Index %2 == 0)
            {
                if(this.subText != null) this.HasSubText = true; 
                outputp.TagName = "figure";                                                 
                SetSubText(ref subtext, ref outputp, "rounded-top");
                TagBuilder img = new TagBuilder("img");                                         
                img.AddCssClass("img-fluid rounded-bottom");                                      
                img.Attributes.Add("src", this.src[this.Index??0]);                     
                img.TagRenderMode = TagRenderMode.SelfClosing;                          
                outputp.Content.AppendHtml(img.RenderSelfClosingTag());
            }
            else
            {
                outputp.TagName = "figure";                                                 
                outputp.AddClass("figure", htmlEncoder: HtmlEncoder.Default);
                TagBuilder img = new TagBuilder("img");                                     
                img.AddCssClass("img-fluid rounded-top");                                  
                img.Attributes.Add("src", this.src[this.Index??0]);                     
                img.TagRenderMode = TagRenderMode.SelfClosing;                          
                outputp.Content.AppendHtml(img.RenderSelfClosingTag());
                if(this.subText != null) this.HasSubText = true; 
                SetSubText(ref subtext, ref outputp, "rounded-bottom");
            }
        }
    }
}
