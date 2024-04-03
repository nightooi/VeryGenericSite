using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace VeryGenericSite.TagHelpers
{
    [HtmlTargetElement("gsdiv", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class WidePanaoramaTaghelper : TagHelper
    {
        [HtmlAttributeName("wph-hidden")]
        public int hidden { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (hidden > 0)
            {
                var b = new TagBuilder("div");
                int transpose = hidden * -25;
                b.Attributes.Add("class", "d-none");
                string tA = $"'top':'{transpose}em'";
                output.Attributes.Add(new("data-transpose-top", tA));
                output.MergeAttributes(b);
                output.TagName = "div";
            }
            else
            {
                output.TagName = "div";
            }
        }
    }
}
