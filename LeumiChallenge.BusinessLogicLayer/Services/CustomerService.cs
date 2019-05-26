using AutoMapper;
using LeumiChallenge.BusinessLogicLayer.DataTransferObjects;
using LeumiChallenge.Common;
using LeumiChallenge.DataAccessLayer;
using Microsoft.Extensions.Logging;
using System;

namespace LeumiChallenge.BusinessLogicLayer.Services
{
	public class CustomerService : ICustomerService
	{
		private	readonly IMapper mapper;
		private	readonly CustomerRepository repository;
		private	readonly ILogger<CustomerService> logger;

		public CustomerService(
			IMapper mapper,
			CustomerRepository repository,
			ILogger<CustomerService> logger)
		{
			this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public virtual PagedList<CustomerDTO> GetCustomersPage(int page, int entries)
		{
			try
			{
				var customers = this.repository.GetPage(page, entries);
				return this.mapper.Map<PagedList<CustomerDTO>>(customers);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, "Failed getting page {0} with {1} customers", page, entries);
				throw exception;
			}
		}

		public virtual CustomerDTO GetCustomerDetails(int id)
		{
			try
			{
				var customer = this.repository.Find(id);
				return this.mapper.Map<CustomerDTO>(customer);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, "Failed getting customer {0}", id);
				throw exception;
			}
		}
	}
}
