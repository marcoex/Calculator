using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Compiler
{
	/// <summary>
	/// Representa uma operação entre dois operandos.
	/// </summary>
    public class Operation
    {
		/// <summary>
		/// Operando 1.
		/// </summary>
		public float? Operand1 { get; set; }

		/// <summary>
		/// Tipo de Operação.
		/// </summary>
		public Operator Operator { get; set; }

		/// <summary>
		/// Operando 2.
		/// </summary>
		public float? Operand2 { get; set; }

		/// <summary>
		/// Efetuar um cálculo entre os operadores definidos.
		/// </summary>
		/// <returns></returns>
		public float Calculate()
		{
			if (!Operand1.HasValue) {
				throw new MissingOperatorException();
			}
			if (!Operand2.HasValue) {
				throw new MissingOperatorException();
			}

			return Operator.Calculate(Operand1.Value, Operand2.Value);
		}
	}
}
