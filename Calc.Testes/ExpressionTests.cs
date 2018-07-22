using Calc.Compiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Testes
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void Expression_Parse()
        {
			Assert.AreEqual(JsonConvert.SerializeObject(Expression.Parse("15+3*8+8,3").Elements).Replace("\"", ""),
				"[{Value:15.0,Type:1},{Value:+,Type:2},{Value:3.0,Type:1},{Value:*,Type:2},{Value:8.0,Type:1},{Value:+,Type:2},{Value:8.3,Type:1}]"
			);
			Assert.AreEqual(JsonConvert.SerializeObject(Expression.Parse("15*8+8").Elements).Replace("\"", ""),
				"[{Value:15.0,Type:1},{Value:*,Type:2},{Value:8.0,Type:1},{Value:+,Type:2},{Value:8.0,Type:1}]"
			);
			Assert.AreEqual(JsonConvert.SerializeObject(Expression.Parse("100*80+8,3-1,0").Elements).Replace("\"", ""),
				"[{Value:100.0,Type:1},{Value:*,Type:2},{Value:80.0,Type:1},{Value:+,Type:2},{Value:8.3,Type:1},{Value:-,Type:2},{Value:1.0,Type:1}]"
			);
		}

		[TestMethod]
		public void Expression_Calculate()
		{
			Assert.AreEqual(new Expression("10+3,3").Calculate(), (double)13.3);
			Assert.AreEqual(new Expression("1*3").Calculate(), (double)3);
			Assert.AreEqual(new Expression("3*3/3").Calculate(), (double)3);
			Assert.AreEqual(new Expression("1*3/2").Calculate(), (double)1.5);
			Assert.AreEqual(new Expression("1500/500*10+3,3").Calculate(), (double)33.3);
			Assert.AreEqual(new Expression("1,5+3*8/2+2,5-1").Calculate(), (double)15);

			Assert.AreEqual(new Expression("-5*-1").Calculate(), (double)5);
			Assert.AreEqual(new Expression("-8/-4").Calculate(), (double)2);
			Assert.AreEqual(new Expression("-3+-1").Calculate(), (double)-4);
			Assert.AreEqual(new Expression("-1-1").Calculate(), (double)-2);
			Assert.AreEqual(new Expression("-1-1").Calculate(), (double)-2);
		}

		[TestMethod]
		public void Expression_ToString()
		{
			Assert.AreEqual(new Expression("-15/3*-1").ToString(), "-15/3*-1");
			Assert.AreEqual(new Expression("--1").ToString(), "--1");
			Assert.AreEqual(new Expression("--1-").ToString(), "--1-");
			Assert.AreEqual(new Expression("555*3333").ToString(), "555*3333");
		}

		[TestMethod]
		public void Expression_Validate()
		{
			Assert.AreEqual(new Expression("1*3+").Validate(), false);
			Assert.AreEqual(new Expression("+10").Validate(), true);
			Assert.AreEqual(new Expression("10/5-").Validate(), false);
			Assert.AreEqual(new Expression("15/15/0").Validate(), true);
			Assert.AreEqual(new Expression("10").Validate(), true);
			Assert.AreEqual(new Expression("10**10").Validate(), false);
			Assert.AreEqual(new Expression("-").Validate(), false);

			Assert.AreEqual(new Expression("--5*-1").Validate(), false);
			Assert.AreEqual(new Expression("-8/-4").Validate(), true);
			Assert.AreEqual(new Expression("-3+-1").Validate(), true);
			Assert.AreEqual(new Expression("-1-1").Validate(), true);
			Assert.AreEqual(new Expression("-1/-1").Validate(), true);
		}
	}
}
