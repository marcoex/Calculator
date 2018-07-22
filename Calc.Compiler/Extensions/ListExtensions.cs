using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Linq
{
    internal static class ListExtensions
    {
		/// <summary>
		/// Faz a clonagem de elementos de uma lista.
		/// </summary>
		/// <typeparam name="T">Tipo de lista.</typeparam>
		/// <param name="list">Objeto de lista.</param>
		/// <returns></returns>
		public static IList<T> Clone<T>(this IList<T> list) where T : ICloneable
		{
			return list.Select(item => (T)item.Clone()).ToList();
		}
	}
}
