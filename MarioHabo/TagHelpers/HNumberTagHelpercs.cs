using Microsoft.AspNetCore.Razor.TagHelpers;
namespace MarioHabo.TagHelpers
{
    [HtmlTargetElement("h", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class HNumberTagHelpercs : TagHelper
    {
        [HtmlAttributeName("h-number")]
        public int? HNumber { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(this.HNumber.HasValue)
            {
                output.TagName = $"h{HNumber.Value}";
            }
        }
    }
}
