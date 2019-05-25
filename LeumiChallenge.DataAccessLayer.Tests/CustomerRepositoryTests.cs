using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeumiChallenge.DataAccessLayer.Tests
{
	[TestClass]
	public class CustomerRepositoryTests
	{
		private readonly CustomerRepository repository;

		public CustomerRepositoryTests()
		{
			var context = new LeumiChallengeDbContext("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=LeumiChallenge_TEST;Integrated Security=true;");
			this.repository = new CustomerRepository(context);
		}

		[TestMethod]
		public async System.Threading.Tasks.Task Customers_CRUD_Tests()
		{
			var customers = this.repository.GetPage(1, 100);

			Assert.IsNotNull(customers);
			Assert.AreEqual(10, customers.Count);

			var customer = new Customer
			{
				CustomerFirstName = "Test",
				CustomerLastName = "Customer"
			};

			this.repository.Create(customer);

			await this.repository.SaveAsync();

			customers = this.repository.GetPage(1, 100);

			Assert.IsNotNull(customers);
			Assert.AreEqual(11, customers.Count);

			this.repository.Delete(customer.CustomerId);

			await this.repository.SaveAsync();

			customers = this.repository.GetPage(1, 100);

			Assert.IsNotNull(customers);
			Assert.AreEqual(10, customers.Count);
		}
	}
}
