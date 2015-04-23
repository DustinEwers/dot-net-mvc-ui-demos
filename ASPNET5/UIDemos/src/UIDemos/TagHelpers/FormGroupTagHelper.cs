
using System;
using Microsoft.AspNet.Razor.Runtime.TagHelpers;

namespace UIDemos.TagHelpers
{
	public class FormgroupTagHelper : TagHelper
    {
        private const string SizeAttributeName = "size";

	    public override void Process(TagHelperContext context, TagHelperOutput output)
	    {
			int size;
			Int32.TryParse(context.AllAttributes[SizeAttributeName].ToString(), out size);

			output.TagName = "div";
			output.Attributes["class"] =  string.Format("form-group col-md-{0}", size);
		    output.Attributes.Remove(SizeAttributeName);
	    }
    }
}