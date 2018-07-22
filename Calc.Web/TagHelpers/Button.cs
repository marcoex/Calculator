using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calc.Web.Enumeradores;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Calc.Web.TagHelpers
{
	[HtmlTargetElement("button", ParentTag = "grid")]
	public class Button : TagHelper
    {
		public string Key { get; set; }

		public string Value { get; set; }

		public ButtonTypeEnum ButtonType { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
			var inner = await output.GetChildContentAsync();
			output.TagName = "button";

			//analisar função
			switch (ButtonType) {
				case ButtonTypeEnum.Operator:
				case ButtonTypeEnum.Operation:
				case ButtonTypeEnum.Complement:
					output.Attributes.Add("value", Value);
					break;
				case ButtonTypeEnum.Command:
					output.Attributes.Add("key", Key);
					output.Attributes.Add("cmd", Value);
					break;
			}
			if (Key != null)
				output.Attributes.SetAttribute("key", Key);

			//analisar estilo
			if (ButtonType == ButtonTypeEnum.Disabled)
				output.Attributes.Add("class", "disabled");
			else if (ButtonType == ButtonTypeEnum.Operator)
				output.Attributes.Add("class", "detach");

			//icone
			//hack:mcontarski:essa parte não ficou muito boa
			if (inner.IsEmptyOrWhiteSpace && (ButtonType == ButtonTypeEnum.Command || ButtonType == ButtonTypeEnum.Operation)) {
				string name;
				switch (Value) {
					case "+": name = "sum";break;
					case "-": name = "minus"; break;
					case "*": name = "multiply"; break;
					case "/": name = "divide"; break;
					default: name = Value; break;
				}
				var image = new TagBuilder("image");
				image.Attributes.Add("src", $"/icons/{name}.svg");
				image.Attributes.Add("width", "24");
				output.Content.AppendHtml(image);
			}
		}
	}
}
