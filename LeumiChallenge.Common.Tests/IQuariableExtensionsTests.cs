using LeumiChallenge.Common.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeumiChallenge.Common.Tests
{
	[TestClass]
	public class IQuariableExtensions
	{
		[TestMethod]
		public void PageEntries_Method_Takes_null_Returns_null()
		{
			IQueryable<int> items = null;
			Assert.IsNull(items.PageEntries(1, 5));
		}

		[TestMethod]
		public void PageEntries_Method_Takes_10_Items_Returns_5_Page1()
		{
			var range = Enumerable.Range(1, 10);

			Assert.AreEqual(10, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			Assert.AreEqual(5, items.PageEntries(1, 5).Count());
		}

		[TestMethod]
		public void PageEntries_Method_Takes_10_Items_Returns_5_Page2()
		{
			var range = Enumerable.Range(1, 10);

			Assert.AreEqual(10, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			Assert.AreEqual(5, items.PageEntries(2, 5).Count());
		}

		[TestMethod]
		public void PageEntries_Method_Takes_14_Items_Returns_5_Page1()
		{
			var range = Enumerable.Range(1, 14);

			Assert.AreEqual(14, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			Assert.AreEqual(5, items.PageEntries(1, 5).Count());
		}

		[TestMethod]
		public void PageEntries_Method_Takes_14_Items_Returns_5_Page2()
		{
			var range = Enumerable.Range(1, 14);

			Assert.AreEqual(14, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			Assert.AreEqual(5, items.PageEntries(2, 5).Count());
		}

		[TestMethod]
		public void PageEntries_Method_Takes_14_Items_Returns_4_Page3()
		{
			var range = Enumerable.Range(1, 14);

			Assert.AreEqual(14, range.Count());

			IQueryable<int> items = new System.Collections.Generic.HashSet<int>(range).AsQueryable();

			Assert.AreEqual(4, items.PageEntries(3, 5).Count());
		}
	}
}
