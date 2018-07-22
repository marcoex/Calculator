using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Compiler
{
	/// <summary>
	/// Representa um operador matemático de multiplicação.
	/// </summary>
	public class MultiplyOperator : Operator
    {
		/// <summary>
		/// Símbolo matemático que representa a operação.
		/// </summary>
		public static readonly char Symbol = '*';

		/// <summary>
		/// Valor do operador.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Tipo do operador.
		/// </summary>
		public TypeEnum Type { get; set; }

		/// <summary>
		/// Efetuar um cálculo com dois operandos.
		/// </summary>
		/// <param name="operand1">Operando 1.</param>
		/// <param name="operand2">Operando 2.</param>
		/// <returns></returns>
		public override float Calculate(float operand1, float operand2)
		{
			return operand1 * operand2;
		}
	}
}
