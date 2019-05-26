using System.Collections.Generic;

namespace LeumiChallenge.BusinessLogicLayer.DataTransferObjects
{
	public class CustomerDTO
	{
		public CustomerDTO()
		{
			this.Messages = new List<TextLessMessageDTO>();
		}

		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public List<TextLessMessageDTO> Messages { get; set; }
	}
}
