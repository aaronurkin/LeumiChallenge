using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace LeumiChallenge.DataAccessLayer
{
	public abstract class RepositoryBase<T> where T : class
    {
		private readonly DbContext context;

		public RepositoryBase(DbContext context)
		{
			this.context = context ?? throw new System.ArgumentNullException(nameof(context));
			this.Query = context.Set<T>();
		}

		protected DbSet<T> Query { get; }

		public virtual T Find(object id)
		{
			return this.Query.Find(id);
		}

		public virtual T Find(Expression<Func<T, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			return this.Query.FirstOrDefault(predicate);
		}

		public virtual void Create(T instance)
		{
			this.Query.Add(instance);
		}

		public virtual void Update(T instance)
		{
			this.Query.Attach(instance);
			this.context.Entry(instance).State = EntityState.Modified;
		}

		public virtual void Delete(object id)
		{
			this.Delete(this.Query.Find(id));
		}

		public virtual void Delete(Expression<Func<T, bool>> predicate)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			this.Delete(this.Query.FirstOrDefault(predicate));
		}

		public virtual Common.PagedList<T> GetPage(int page, int entries)
		{
			return new Common.PagedList<T>(this.Query.AsNoTracking(), page, entries);
		}

		public virtual Common.PagedList<T> GetPage(Expression<Func<T, bool>> predicate, int page, int entries)
		{
			if (predicate == null)
			{
				throw new ArgumentNullException(nameof(predicate));
			}

			return new Common.PagedList<T>(this.Query.Where(predicate).AsNoTracking(), page, entries);
		}

		public virtual System.Threading.Tasks.Task<int> SaveAsync()
		{
			return this.context.SaveChangesAsync();
		}

		private void Delete(T instance)
		{
			if (instance != null)
			{
				this.Query.Remove(instance);
			}
		}
	}
}
