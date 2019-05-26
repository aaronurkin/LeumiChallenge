using LeumiChallenge.BusinessLogicLayer.DataTransferObjects;
using LeumiChallenge.Common;

namespace LeumiChallenge.BusinessLogicLayer.Services
{
	public interface ICustomerService
	{
		PagedList<CustomerDTO> GetCustomersPage(int page, int entries);

		CustomerDTO GetCustomerDetails(int id);
	}
}
