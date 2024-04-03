using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
using VeryGenericSite.Model;

namespace VeryGenericSite.TagHelpers
{
    [HtmlTargetElement("WideInfoText", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class WideInfoTextTagHelper : TagHelper
    {

        [HtmlAttributeName("sub-header-text")]
        public string SubHeaderText { get; set; }

        [HtmlAttributeName("text")]
        public string Text { get; set; }

        [HtmlAttributeName("type-redirect")]
        public RedirectType TypeRedirect { get; set; }

        [HtmlAttributeName("header-number")]
        public int HeaderNumber { get; set; }
        public HNumberTagHelpercs HNumberTagHelper { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            HNumberTagHelper = new HNumberTagHelpercs();
            HNumberTagHelper.Init(context);
            HNumberTagHelper.HNumber = HeaderNumber;
            HNumberTagHelper.Process(context, output);

        }
    }
}