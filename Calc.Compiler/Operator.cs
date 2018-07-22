using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Compiler
{
	/// <summary>
	/// Represeta operador genérico.
	/// </summary>
	public abstract class Operator : IOperator
	{
		/// <summary>
		/// Listagem de-para de símbolo e operador matemático.
		/// </summary>
		protected static Dictionary<char, Type> Relations = new Dictionary<char, Type>() {
			[SumOperator.Symbol]		= typeof(SumOperator),
			[MinusOperator.Symbol]		= typeof(MinusOperator),
			[MultiplyOperator.Symbol]	= typeof(MultiplyOperator),
			[DivideOperator.Symbol]		= typeof(DivideOperator),
		};

		/// <summary>
		/// Efetua um cálculo matemático entre dois operandos.
		/// </summary>
		/// <param name="operand1">Operando 1.</param>
		/// <param name="operand2">Operando 2.</param>
		/// <returns></returns>
		public abstract double Calculate(double operand1, double operand2);

		/// <summary>
		/// Retorna um operador através do símbolo matemático.
		/// </summary>
		/// <param name="symbol"></param>
		/// <returns></returns>
		public static IOperator FromSymbol(char symbol)
		{
			return Activator.CreateInstance(Relations[symbol]) as IOperator;
		}

		/// <summary>
		/// Retorna um operador através do elemento associado.
		/// </summary>
		/// <param name="element"></param>
		/// <returns></returns>
		public static IOperator FromElement(IElement element)
		{
			if (element.Type != TypeEnum.Symbol)
				return null;
			
			char symbol = (char)element.Value;
			return Activator.CreateInstance(Relations[symbol]) as IOperator;
		}
	}
}
