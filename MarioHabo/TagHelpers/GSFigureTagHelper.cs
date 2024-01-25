using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

using NuGet.Packaging;
using NuGet.Protocol;

using System.CodeDom;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using System.Text;

namespace MarioHabo.TagHelpers
{
    /// <summary>
    /// If src value is null, will throw.
    /// Image defaults to lower left corner.
    /// Unifinnished moving this to a component implementation.
    /// </summary>
    [HtmlTargetElement("gsfigure", Attributes = "gs*", ParentTag = "div", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class GSFigureTagHelper : TagHelper, ITagHelperComponent
    {
        [HtmlAttributeName("class", DictionaryAttributePrefix = "gs-")]
        public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder outer = new("a");
            TagBuilder inner = new("a");
            output.Content.AppendHtml(BuildTag(ref outer,in inner, TagBuilderDef.undefined));
            base.Process(context, output);
        }
        bool Conditionals(string key, object? value)
        {
            while (value is not null)
            {
                switch (key)
                {
                    case "image":
                        this.Attributes.Add("src", this.Attributes["image"]);
                        return true;
                    case "src":
                        return true;
                    case "caption":
                        return true;
                    case "right":
                        return (bool)value;
                    case "top":
                        return (bool)value;
                    case "figure":
                        return (bool)value;
                    case "figcap":
                        return (bool)value;
                    case "figurecap":
                        return (bool)value;
                    case "fig":
                        return (bool)value;
                    case "capupper":
                        return (bool)value;
                    case "text-center":
                        return (bool)value;
                    case "text-end":
                        return (bool)value;
                    case "text-start":
                        return (bool)value;
                    case "article":
                        return true;
                    case "article-justify-left":
                        return (bool)value;
                    case "article-justify-right":
                        return (bool)value;
                    case "article-left":
                        return (bool)value;
                    case "article-right":
                        return (bool)value;
                    case "source":
                        this.Attributes.Add("src", this.Attributes["src"]);
                        return true;
                    default:
                        throw new NotImplementedException();
                }
            }
            return false;
        }
        private enum TagBuilderDef { HasOuterWrapper, HasblockWrapper, HasInnerWrapper, HasImage, HasCaption, HasArticle, undefined, end}
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attr">          leave empty, recursive function, defaults too empty string</param>
        /// <param name="surrounding">   insert new Tagbuilder</param>
        /// <param name="newTag">        insert new Tagbuilder</param>
        /// <param name="helper">        insert private private class TagbuilderDef.undefined</param>
        /// <returns><author>if you borke it, im not debuggin it, just redownload the package.</author></returns>
        private TagBuilder BuildTag(ref TagBuilder surrounding, in TagBuilder newTag, TagBuilderDef helper, string attr = "")
        {
            switch (helper)
            {
                case GSFigureTagHelper.TagBuilderDef.undefined:
                    var a = new TagBuilder("div");
                    a.AddCssClass("d-flex mt-3");
                    surrounding = new TagBuilder(a);
                    return BuildTag(ref surrounding, new TagBuilder("div"), TagBuilderDef.HasOuterWrapper, "d-block");
                case GSFigureTagHelper.TagBuilderDef.HasOuterWrapper:
                    newTag.AddCssClass(attr);
                    surrounding.InnerHtml.AppendHtml(newTag.RenderStartTag());
                    StringBuilder classes = new StringBuilder();
                    if(Conditionals("top", Attributes["top"]))
                    {
                        classes.Append("gs-top");
                    }
                    else 
                    {
                        classes.Append("gs-bottom");
                    }
                    if(Conditionals("right", Attributes["right"]))
                    {
                        classes.Append(" gs-right");
                    }
                    else
                    {
                        classes.Append(" gs-left");
                    }
                    BuildTag(ref surrounding, new TagBuilder("div"), TagBuilderDef.HasblockWrapper, classes.ToString());
                    surrounding.InnerHtml.AppendHtml(newTag.RenderEndTag());
                    return surrounding;
                case GSFigureTagHelper.TagBuilderDef.HasblockWrapper:
                    newTag.AddCssClass(attr);
                    surrounding.InnerHtml.AppendHtml(newTag.RenderStartTag());
                    if(Conditionals("caption", this.Attributes["caption"]))
                    {
                        if (Conditionals("capupper", this.Attributes["capupper"]))
                        {
                            BuildTag(ref surrounding, new("div"), TagBuilderDef.HasInnerWrapper, "flex-column-reverse d-flex me-2");
                        }
                         else
                        {
                            BuildTag(ref surrounding, new("div"), TagBuilderDef.HasInnerWrapper, "flex-column d-flex me-2");
                        }
                    }
                    else
                    {
                        BuildTag(ref surrounding, new("div"), TagBuilderDef.HasCaption,"d-flex me-2");
                    }
                    surrounding.InnerHtml.AppendHtml(newTag.RenderEndTag());
                    if(Conditionals("article", this.Attributes["article"]))
                    {
                        foreach(var i in this.Attributes.Keys.Where(x => x.Contains("left") || x.Contains("right")))
                        {
                            if(i.Contains("left"))
                            {
                                var k = new TagBuilder("p");
                                k.AddCssClass("text-left");
                                surrounding.InnerHtml.AppendHtml(k.RenderStartTag());
                                surrounding.InnerHtml.Append((string)Attributes["article"]);
                                surrounding.InnerHtml.AppendHtml(k.RenderEndTag());
                            }
                            else
                            {
                                var k = new TagBuilder("p");
                                k.AddCssClass("text-right");
                                surrounding.InnerHtml.AppendHtml(k.RenderStartTag());
                                surrounding.InnerHtml.Append((string)Attributes["article"]);
                                surrounding.InnerHtml.AppendHtml(k.RenderEndTag());
                            }
                        }
                    }
                    break;
                case GSFigureTagHelper.TagBuilderDef.HasInnerWrapper:
                    newTag.AddCssClass(attr);
                    surrounding.InnerHtml.AppendHtml(newTag.RenderStartTag());
                    foreach (var attrib in this.Attributes.Keys.Where((x)=> x.Contains("text")))
                    {
                        if(Conditionals(attrib, this.Attributes[attrib]))
                        {
                            BuildTag(ref surrounding, new("p"), TagBuilderDef.HasCaption, attrib);
                            surrounding.InnerHtml.AppendHtml(newTag.RenderEndTag());
                        }
                    }
                    return surrounding;
                case GSFigureTagHelper.TagBuilderDef.HasCaption:
                    if (Conditionals("capupper", Attributes["capupper"]))
                    {
                        BuildTag(ref surrounding, new("img"), TagBuilderDef.HasImage, "someimg rounded-bottom shadow-lg rounded");
                        newTag.AddCssClass(attr + " rounded-top bg-white mb-0 shadow-lg");
                        surrounding.InnerHtml.AppendHtml(newTag.RenderStartTag());
                        surrounding.InnerHtml.Append((string)this.Attributes["caption"]);
                        surrounding.InnerHtml.AppendHtml(newTag.RenderEndTag());
                    }
                    else if (Attributes["capupper"] == null)
                    {
                        BuildTag(ref surrounding, new("img"), TagBuilderDef.HasImage, "someimg rounded shadow  rounded");
                    }
                    else
                    {
                        BuildTag(ref surrounding, new("img"), TagBuilderDef.HasImage, "someimg rounded-top shadow-lg");
                        newTag.AddCssClass(attr + " rounded-bottom bg-white mb-0 shadow-lg");
                        surrounding.InnerHtml.AppendHtml(newTag.RenderStartTag());
                        surrounding.InnerHtml.Append((string)this.Attributes["caption"]);
                        surrounding.InnerHtml.AppendHtml(newTag.RenderEndTag());
                    }
                    return surrounding;
                case GSFigureTagHelper.TagBuilderDef.HasImage:
                    newTag.AddCssClass(attr);
                    newTag.Attributes.Add("src", (string)Attributes["src"]);
                    surrounding.InnerHtml.AppendHtml(newTag.RenderSelfClosingTag());
                    return surrounding;
                default:
                    surrounding.InnerHtml.AppendHtml(newTag.RenderEndTag());
                    return surrounding;
            }
            return surrounding;
        }
    }
}
