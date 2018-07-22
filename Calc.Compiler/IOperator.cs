namespace Calc.Compiler
{
	public interface IOperator
	{
		/// <summary>
		/// Efetua um cálculo matemático entre dois operandos.
		/// </summary>
		/// <param name="operand1">Operando 1.</param>
		/// <param name="operand2">Operando 2.</param>
		/// <returns></returns>
		double Calculate(double operand1, double operand2);
	}
}