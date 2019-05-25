using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeumiChallenge.DataAccessLayer.Tests
{
	[TestClass]
	public class MessageRepositoryTests
	{
		private readonly MessageRepository repository;

		public MessageRepositoryTests()
		{
			var context = new LeumiChallengeDbContext("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=LeumiChallenge_TEST;Integrated Security=true;");
			this.repository = new MessageRepository(context);
		}

		[TestMethod]
		public async System.Threading.Tasks.Task Messages_CRUD_Tests()
		{
			var messages = this.repository.GetPage(1, 100);

			Assert.IsNotNull(messages);
			Assert.AreEqual(23, messages.Count);

			var message = new Message
			{
				CustomerId = 1,
				MessageFrom = "Test",
				MessageSubject = "Test Subject",
				MessageText = "Test Text"
			};

			this.repository.Create(message);

			await this.repository.SaveAsync();

			messages = this.repository.GetPage(1, 100);

			Assert.IsNotNull(messages);
			Assert.AreEqual(24, messages.Count);

			this.repository.Delete(message.MessageId);

			await this.repository.SaveAsync();

			messages = this.repository.GetPage(1, 100);

			Assert.IsNotNull(messages);
			Assert.AreEqual(23, messages.Count);
		}
	}
}
