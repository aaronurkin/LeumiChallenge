using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeumiChallenge.Common.Tests
{
	[TestClass]
	public class PagedListTests
	{
		[TestMethod]
		public void PagedList_constructor_creates_instance_with_14_total_entries_at_3_pages_with_5_entiries_on_the_first_page()
		{
			var range = Enumerable.Range(1, 14);

			Assert.AreEqual(14, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			var pagedList = new PagedList<int>(items, 1, 5);

			Assert.AreEqual(1, pagedList.Page);
			Assert.AreEqual(5, pagedList.Count);
			Assert.AreEqual(3, pagedList.TotalPages);
			Assert.AreEqual(5, pagedList.PageEntries);
			Assert.AreEqual(14, pagedList.TotalEntries);
		}

		[TestMethod]
		public void PagedList_constructor_creates_instance_with_14_total_entries_at_3_pages_with_5_entiries_on_the_second_page()
		{
			var range = Enumerable.Range(1, 14);

			Assert.AreEqual(14, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			var pagedList = new PagedList<int>(items, 2, 5);

			Assert.AreEqual(2, pagedList.Page);
			Assert.AreEqual(5, pagedList.Count);
			Assert.AreEqual(3, pagedList.TotalPages);
			Assert.AreEqual(5, pagedList.PageEntries);
			Assert.AreEqual(14, pagedList.TotalEntries);
		}

		[TestMethod]
		public void PagedList_constructor_creates_instance_with_14_total_entries_at_3_pages_with_4_entiries_on_the_third_page()
		{
			var range = Enumerable.Range(1, 14);

			Assert.AreEqual(14, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			var pagedList = new PagedList<int>(items, 3, 5);

			Assert.AreEqual(3, pagedList.Page);
			Assert.AreEqual(4, pagedList.Count);
			Assert.AreEqual(3, pagedList.TotalPages);
			Assert.AreEqual(5, pagedList.PageEntries);
			Assert.AreEqual(14, pagedList.TotalEntries);
		}
	}
}
