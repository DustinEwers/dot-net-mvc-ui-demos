using Microsoft.AspNet.Razor.Runtime.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vNextUIDemos.TagHelpers
{
    [HtmlTargetElement("panel")]
    public class PanelTagHelper: TagHelper
    {
        [HtmlAttributeName("title")]
        public string title { get; set; }
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes["class"] = "panel panel-default";
            
            output.PreContent.SetContentEncoded(string.Format("<div class='panel-heading'>{0}</div><div class='panel-body'>", title));

            output.PostContent.SetContentEncoded("</div></div>");
        }
    }
}
