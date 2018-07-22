using System;
using System.Runtime.Serialization;

namespace Calc.Compiler
{
	/// <summary>
	/// Ocorre quando o formato textual da expressão não é válido.
	/// </summary>
	[Serializable]
	public class InvalidExpressionFormat : Exception
	{
		public InvalidExpressionFormat() : base("Expressão em formato inválido.")
		{
		}

		public InvalidExpressionFormat(string message) : base(message)
		{
		}

		public InvalidExpressionFormat(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidExpressionFormat(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}