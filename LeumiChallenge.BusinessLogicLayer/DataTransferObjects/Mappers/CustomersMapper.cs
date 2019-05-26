using AutoMapper;
using LeumiChallenge.Common;
using LeumiChallenge.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeumiChallenge.BusinessLogicLayer.DataTransferObjects.Mappers
{
	public class CustomersMapper : Profile
	{
		public CustomersMapper()
		{
			this.CreateMap<Customer, CustomerDTO>()
				.ForMember(dto => dto.Id, opts => opts.MapFrom(source => source.CustomerId))
				.ForMember(dto => dto.Messages, opts => opts.MapFrom(source => source.Messages))
				.ForMember(dto => dto.LastName, opts => opts.MapFrom(source => source.CustomerLastName))
				.ForMember(dto => dto.FirstName, opts => opts.MapFrom(source => source.CustomerFirstName));

			this.CreateMap<PagedList<Customer>, PagedList<CustomerDTO>>()
				.ConstructUsing(this.PagedListInitializer)
				.ForAllMembers(opts => opts.Ignore());
		}

		private PagedList<CustomerDTO> PagedListInitializer(PagedList<Customer> source, ResolutionContext context)
		{
			if (source != null)
			{
				return new PagedList<CustomerDTO>(source.Select(context.Mapper.Map<CustomerDTO>), source.TotalEntries, source.Page, source.PageEntries);
			}

			return null;
		}
	}
}
