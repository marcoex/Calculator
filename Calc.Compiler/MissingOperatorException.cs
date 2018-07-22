using System;
using System.Runtime.Serialization;

namespace Calc.Compiler
{
	[Serializable]
	public class MissingOperatorException : Exception
	{
		public MissingOperatorException() : base($"Operador necessário faltando.")
		{
		}

		public MissingOperatorException(string message) : base(message)
		{
		}

		public MissingOperatorException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected MissingOperatorException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}