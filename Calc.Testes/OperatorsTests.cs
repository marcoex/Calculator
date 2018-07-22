using Calc.Compiler;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Testes
{
    [TestClass]
    public class OperatorsTests
	{
        [TestMethod]
        public void DivideOperator_Calculate()
        {
			var op = new DivideOperator();

			Assert.AreEqual(op.Calculate(9, 3), 3);
			Assert.AreEqual(op.Calculate(9, -3), -3);
			Assert.AreEqual(op.Calculate(-9, 3), -3);
			Assert.AreEqual(op.Calculate(-9, -3), 3);
		}

		[TestMethod]
		public void MinusOperator_Calculate()
		{
			var op = new MinusOperator();

			Assert.AreEqual(op.Calculate(9, 3), 6);
			Assert.AreEqual(op.Calculate(9, -3), 12);
			Assert.AreEqual(op.Calculate(-9, 3), -12);
			Assert.AreEqual(op.Calculate(-9, -3), -6);
		}

		[TestMethod]
		public void MultiplyOperator_Calculate()
		{
			var op = new MultiplyOperator();

			Assert.AreEqual(op.Calculate(9, 3), 27);
			Assert.AreEqual(op.Calculate(9, -3), -27);
			Assert.AreEqual(op.Calculate(-9, 3), -27);
			Assert.AreEqual(op.Calculate(-9, -3), 27);
		}

		[TestMethod]
		public void SumOperator_Calculate()
		{
			var op = new SumOperator();

			Assert.AreEqual(op.Calculate(9, 3), 12);
			Assert.AreEqual(op.Calculate(9, -3), 6);
			Assert.AreEqual(op.Calculate(-9, 3), -6);
			Assert.AreEqual(op.Calculate(-9, -3), -12);
		}
	}
}
