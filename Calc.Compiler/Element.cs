namespace Calc.Compiler
{
	public class Element : IElement
	{
		/// <summary>
		/// Conteúdo do elemento.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Tipo do elemento.
		/// </summary>
		public TypeEnum Type { get; set; }
	}
}