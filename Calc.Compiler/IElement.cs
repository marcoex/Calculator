namespace Calc.Compiler
{
	public interface IElement
	{
		/// <summary>
		/// Conteúdo do elemento.
		/// </summary>
		object Value { get; set; }

		/// <summary>
		/// Tipo do elemento.
		/// </summary>
		TypeEnum Type { get; set; }
	}
}