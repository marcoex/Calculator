using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Calc.Compiler
{
	/// <summary>
	/// Representa uma expressão matemática de operações básicas.
	/// </summary>
	public class Expression
	{
		/// <summary>
		/// Listagem de elementos da expressão.
		/// </summary>
		public IEnumerable<IElement> Elements { get; private set; } = new Collection<Element>();

		/// <summary>
		/// Retonar uma instância de <see cref="Expression"/>.
		/// </summary>
		public Expression()
		{
		}

		/// <summary>
		/// Retonar uma instância de <see cref="Expression"/>.
		/// </summary>
		/// <param name="exp">Representação textual.</param>
		public Expression(string exp)
		{
			if (exp == null)
				return;

			Elements = Parse(exp).Elements;
		}

		/// <summary>
		/// Converte uma expressão textual em objeto de <see cref="Expression"/>.
		/// </summary>
		/// <param name="expression"></param>
		/// <returns></returns>
		public static Expression Parse(string expression)
		{
			var list = new Collection<Element>();
			for (int i = 0; i < expression.Length; i++) {
				char pre = i - 1 >= 0 ? expression[i - 1] : (char)0;
				char chr = expression[i];
				char pos = i + 1 <= expression.Length - 1 ? expression[i + 1] : (char)0;
				if (PartOfNumber(pre, chr, pos)) {
					string number = "";
					for (; i < expression.Length; i++) {
						pre = i - 1 >= 0 ? expression[i - 1] : (char)0;
						chr = expression[i];
						pos = i + 1 <= expression.Length - 1 ? expression[i + 1] : (char)0;
						if (!PartOfNumber(pre, chr, pos)) {  //se for simbolo
							i--;  //deixar para procedimento posterior
							break;
						}
						number += chr;
					}
					list.Add(new Element() { Type = TypeEnum.Numeric, Value = Double.Parse(number) });
				} else {  //se for numérico
					list.Add(new Element() { Type = TypeEnum.Symbol, Value = chr });
				}
			}

			return new Expression { Elements = list };
		}

		/// <summary>
		/// Valida a expressão atual para determinar se é calculável.
		/// </summary>
		/// <returns></returns>
		public bool Validate()
		{
			return Validate(Elements);
		}

		/// <summary>
		/// Valida uma lista de elementos para determinar se são calculáveis.
		/// </summary>
		/// <param name="elements"></param>
		/// <returns></returns>
		protected static bool Validate(IEnumerable<IElement> elements)
		{
			var expression = ToString(elements);
			string pattern = "^{number}({operator}{number})*$";
			pattern = pattern.Replace("{number}", @"([+-]?(\d+(,\d+)?))");
			pattern = pattern.Replace("{operator}", @"[*/+-]");
			return Regex.IsMatch(expression, pattern);
		}

		/// <summary>
		/// Converter uma lista de operações compilada na sua representação textual.
		/// </summary>
		/// <returns></returns>
		protected static string ToString(IEnumerable<IElement> elements)
		{
			string result = "";
			foreach (var item in elements) {
				result += item.Value.ToString();
			}
			return result;
		}

		/// <summary>
		/// Converter uma expressão compilada na sua representação textual.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return ToString(Elements);
		}

		/// <summary>
		/// Verifica se um caracter é parte válida de um valor numérico no contexto em que está inserido.
		/// </summary>
		/// <param name="pre">Caracter anterior.</param>
		/// <param name="now">Caracter.</param>
		/// <param name="pos">Caracter posterior.</param>
		/// <returns></returns>
		private static bool PartOfNumber(char pre, char now, char pos)
		{
			if (now == ',') 
				return true;
			if (Char.IsNumber(now)) 
				return true;
			
			var operations = new char?[] { '+', '-', '*', '/' };
			var signals = new char?[] { '+', '-' };

			//situações em que carater é sinal do número
			if (pre == (char)0 && signals.Contains(now) && Char.IsNumber(pos))  //primeiro sinal: vazio, [sinal], número
				return true;
			if (operations.Contains(pre) && signals.Contains(now) && Char.IsNumber(pos))  //operação, [sinal], número
				return true;

			//caso contrário
			return false;
		}

		/// <summary>
		/// Efetuar o cálculo da expressão atual.
		/// </summary>
		/// <returns></returns>
		public double Calculate()
		{
			if (!Validate()) {
				throw new InvalidExpressionFormat();
			}

			//fazer uma cópia de trabalho
			var elements = Elements.ToList().GetRange(0, Elements.Count());

			for (int p = 1; p <= 2; p++) {  //duas passadas, uma para precedência e outra para demais operadores
				if (elements.Count == 1)
					break;  //já terminou

				Type[] targetOp = null;
				if (p == 1)
					targetOp = new Type[] { typeof(MultiplyOperator), typeof(DivideOperator) };

				for (int i = 0; i < elements.Count; i++) {
					if (elements[i].Type != TypeEnum.Symbol)
						continue;
					var @operator = Operator.FromElement(elements[i]);
					if (targetOp != null) {
						if (!targetOp.Contains(@operator.GetType())) {
							continue;
						}
					}

					//happy way
					double operand1 = (double)elements[i - 1].Value;
					double operand2 = (double)elements[i + 1].Value;

					//fazer a operação e remover os operadores
					elements[i].Type = TypeEnum.Numeric;
					elements[i].Value = @operator.Calculate(operand1, operand2);
					elements.RemoveAt(i - 1);
					elements.RemoveAt(i);

					i--;  //reposicionar para próximo elemento não computado
				}
			}
			return (double)elements[0].Value;
		}
	}
}
