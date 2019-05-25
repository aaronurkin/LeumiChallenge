namespace LeumiChallenge.DataAccessLayer
{
	public class MessageRepository : RepositoryBase<Message>
	{
		public MessageRepository(LeumiChallengeDbContext context)
			: base(context)
		{
		}
	}
}
