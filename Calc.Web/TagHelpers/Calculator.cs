using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calc.Web.Enumeradores;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Calc.Web.TagHelpers
{
    [HtmlTargetElement("calculator")]
	[RestrictChildren("visor", "grid")]
	public class Calculator : TagHelper
    {
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
			await output.GetChildContentAsync();
			output.TagName = "div";
			output.Attributes.Add("class", "calculator");
        }
    }
}
