using AutoMapper;
using LeumiChallenge.BusinessLogicLayer.DataTransferObjects;
using LeumiChallenge.Common;
using System.Linq;

namespace LeumiChallenge.WebApp.Models.Mappers
{
	public class CustomerMapper : Profile
	{
		public CustomerMapper()
		{
			this.CreateMap<CustomerDTO, CustomerViewModel>()
				.ForMember(vm => vm.Id, opts => opts.MapFrom(dto => dto.Id))
				.ForMember(vm => vm.Messages, opts => opts.MapFrom(dto => dto.Messages))
				.ForMember(vm => vm.LastName, opts => opts.MapFrom(dto => dto.LastName))
				.ForMember(vm => vm.FirstName, opts => opts.MapFrom(dto => dto.FirstName));

			this.CreateMap<PagedList<CustomerDTO>, PagedList<CustomerViewModel>>()
				.ConstructUsing(this.PagedListInitializer)
				.ForAllMembers(opts => opts.Ignore());
		}

		private PagedList<CustomerViewModel> PagedListInitializer(PagedList<CustomerDTO> source, ResolutionContext context)
		{
			if (source != null)
			{
				return new PagedList<CustomerViewModel>(source.Select(context.Mapper.Map<CustomerViewModel>), source.TotalEntries, source.Page, source.PageEntries);
			}

			return null;
		}
	}
}
