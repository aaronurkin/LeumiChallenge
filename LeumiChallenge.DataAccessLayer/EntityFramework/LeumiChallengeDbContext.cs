using Microsoft.EntityFrameworkCore;

namespace LeumiChallenge.DataAccessLayer
{
	public class LeumiChallengeDbContext : DbContext
	{
		private readonly string connectionString;

		public LeumiChallengeDbContext(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public LeumiChallengeDbContext(DbContextOptions<LeumiChallengeDbContext> options)
			: base(options)
		{
		}

		public DbSet<Message> Messages { get; set; }

		public DbSet<Customer> Customers { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(this.connectionString))
			{
				optionsBuilder.UseSqlServer(this.connectionString);
				base.OnConfiguring(optionsBuilder);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Customer>(customer =>
			{
				customer
					.ToTable("Customers")
					.HasKey(c => c.CustomerId);

				customer
					.HasMany(c => c.Messages)
					.WithOne()
					.HasForeignKey(m => m.CustomerId);
			});

			modelBuilder.Entity<Message>(message =>
			{
				message
					.ToTable("Messages")
					.HasKey(c => c.MessageId);
			});
		}
	}
}
