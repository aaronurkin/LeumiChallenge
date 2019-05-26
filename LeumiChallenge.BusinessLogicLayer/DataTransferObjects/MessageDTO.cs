namespace LeumiChallenge.BusinessLogicLayer.DataTransferObjects
{
	public class MessageDTO
	{
		public int Id { get; set; }

		public string From { get; set; }

		public string Text { get; set; }

		public string Subject { get; set; }

		public int CustomerId { get; set; }
	}
}
