namespace LeumiChallenge.DataAccessLayer
{
	public class Message
    {
		public int MessageId { get; set; }

		public string MessageFrom { get; set; }

		public string MessageText { get; set; }

		public string MessageSubject { get; set; }

		public int CustomerId { get; set; }
	}
}
