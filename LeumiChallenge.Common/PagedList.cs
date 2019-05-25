using LeumiChallenge.Common.Extensions;
using System.Linq;

namespace LeumiChallenge.Common
{
	public class PagedList<T> : System.Collections.Generic.List<T>
    {
		public int Page { get; }

		public int TotalPages { get; }

		public int TotalEntries { get; }

		public int PageEntries { get; }

		public bool HasPreviousPage => this.Page > 1;

		public bool HasNextPage => this.Page < this.TotalPages;

		public PagedList(IQueryable<T> items, int page, int entries)
			: this(items.PageEntries(page, entries), items?.Count(), page, entries)
		{
		}

		public PagedList(System.Collections.Generic.IEnumerable<T> items, int? totalCount, int page, int entries)
		{
			var pageEntries = entries < 1 ? 5 : entries;
			var totalEntries = System.Math.Max(totalCount ?? 0, 0);
			var totalPages = (int)System.Math.Ceiling(totalEntries / (double)pageEntries);

			this.TotalPages = totalPages;
			this.PageEntries = pageEntries;
			this.TotalEntries = totalEntries;
			this.Page = System.Math.Min(page < 1 ? 1 : page, totalPages);

			if (items != null)
			{
				this.AddRange(items);
			}
		}
	}
}
