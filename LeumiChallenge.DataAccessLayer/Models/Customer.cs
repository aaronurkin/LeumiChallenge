using System.Collections.Generic;

namespace LeumiChallenge.DataAccessLayer
{
	public class Customer
    {
		public Customer()
		{
			this.Messages = new HashSet<Message>();
		}

		public int CustomerId { get; set; }

		public string CustomerFirstName { get; set; }

		public string CustomerLastName { get; set; }

		public ICollection<Message> Messages { get; set; }
	}
}
