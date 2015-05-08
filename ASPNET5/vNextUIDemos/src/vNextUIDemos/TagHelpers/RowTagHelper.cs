using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace vNextUIDemos.TagHelpers
{
    public class RowTagHelper : TagHelper
    {
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = "div";
			output.Attributes["class"] = "row";
		}
	}
}