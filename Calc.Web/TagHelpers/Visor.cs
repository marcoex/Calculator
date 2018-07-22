using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calc.Web.Enumeradores;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Calc.Web.TagHelpers
{
    [HtmlTargetElement("visor", ParentTag = "calculator")]
    public class Visor : TagHelper
    {
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
			await output.GetChildContentAsync();
			output.TagName = "input";
			output.Attributes.Add("type", "text");
			output.Attributes.Add("disabled", "disabled");
			output.Attributes.Add("class", "visor");
        }
    }
}
