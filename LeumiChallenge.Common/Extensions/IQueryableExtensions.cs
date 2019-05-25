using System.Linq;

namespace LeumiChallenge.Common.Extensions
{
	public static class IQueryableExtensions
	{
		public static IQueryable<T> PageEntries<T>(this IQueryable<T> items, int currentPage, int pageEntries)
		{
			if (items != null)
			{
				var entries = pageEntries < 1 ? 5 : pageEntries;

				return items.Skip((System.Math.Max(currentPage, 1) - 1) * entries).Take(entries);
			}

			return null;
		}
	}
}
