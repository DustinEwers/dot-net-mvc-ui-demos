using System;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace vNextUIDemos.TagHelpers
{
    [HtmlTargetElement("formgroup")]
    public class FormgroupTagHelper : TagHelper
    {
        [HtmlAttributeName("size")]
        public string columnSize { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
	    {
			int size;
			Int32.TryParse(columnSize, out size);

			output.TagName = "div";
			output.Attributes["class"] =  string.Format("form-group col-md-{0}", size);
	    }
    }
}