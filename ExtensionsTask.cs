using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_slideviews
{
	public static class ExtensionsTask
	{
		public static double Median(this IEnumerable<double> items)
		{
			var list = items.OrderBy(item => item).ToList();
			if (list.Count == 0)
				throw new InvalidOperationException();
			if (list.Count % 2 == 0)
				return (double)((list[list.Count / 2] + list[list.Count / 2 - 1]) / 2);
			return list[list.Count / 2];
		}
		public static IEnumerable<Tuple<T, T>> Bigrams<T>(this IEnumerable<T> items)
		{
			var counter = 0;
			T holder = default(T);
			foreach (var item in items)
			{
				if (counter > items.Count() - 1)
					break;
				else if (counter == 0)
				{
					holder = item;
				}
				else
				{
					yield return new Tuple<T, T>(holder, item);
					holder = item;
				}
				counter++;
			}
		}
	}
}
