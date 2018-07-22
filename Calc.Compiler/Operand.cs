using System;
using System.Collections.Generic;
using System.Text;

namespace Calc.Compiler
{
	/// <summary>
	/// Representa um operando (valor numérico).
	/// </summary>
	public class Operand : Element
	{
		public new float Value { get; set; }
	}
}
