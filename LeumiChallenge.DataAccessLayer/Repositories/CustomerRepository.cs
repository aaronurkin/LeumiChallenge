using System;
using System.Linq;
using System.Linq.Expressions;
using LeumiChallenge.Common;
using Microsoft.EntityFrameworkCore;

namespace LeumiChallenge.DataAccessLayer
{
	public class CustomerRepository : RepositoryBase<Customer>
    {
		public CustomerRepository(LeumiChallengeDbContext context)
			: base(context)
		{
		}

		public override PagedList<Customer> GetPage(int page, int entries)
		{
			return new PagedList<Customer>(this.Query.Include(c => c.Messages).AsNoTracking(), page, entries);
		}

		public override PagedList<Customer> GetPage(Expression<Func<Customer, bool>> predicate, int page, int entries)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			return new PagedList<Customer>(this.Query.Include(c => c.Messages).Where(predicate).AsNoTracking(), page, entries);
		}

		public override Customer Find(object id)
		{
			return this.Query.Include(c => c.Messages).FirstOrDefault(c => c.CustomerId == (int)id);
		}

		public override Customer Find(Expression<Func<Customer, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			return this.Query.Include(c => c.Messages).FirstOrDefault(predicate);
		}
	}
}
