using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calc.Compiler;
using Microsoft.AspNetCore.Mvc;

namespace Calc.Web.Controllers
{
    [Route("api/[controller]")]
    public class ExpressionController : Controller
    {
        [HttpPost]
		[Route("Calculate")]
		public double? Calculate(string exp)
        {
			exp = exp.Replace(" ", "+");
			var exprObj = new Expression(exp);
			if (!exprObj.Validate()) {
				return null;
			}

			return exprObj.Calculate();
        }
    }
}
