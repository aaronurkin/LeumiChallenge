using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeumiChallenge.WebApp.Models
{
	public class CustomerViewModel
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public List<ShortMessageViewModel> Messages { get; set; }
	}
}
