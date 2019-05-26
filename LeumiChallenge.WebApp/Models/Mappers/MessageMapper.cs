using AutoMapper;
using LeumiChallenge.BusinessLogicLayer.DataTransferObjects;

namespace LeumiChallenge.WebApp.Models.Mappers
{
	public class MessageMapper : Profile
	{
		public MessageMapper()
		{
			this.CreateMap<MessageDTO, MessageViewModel>()
				.ForMember(vm => vm.Id, opts => opts.MapFrom(dto => dto.Id))
				.ForMember(vm => vm.From, opts => opts.MapFrom(dto => dto.From))
				.ForMember(vm => vm.Text, opts => opts.MapFrom(dto => dto.Text))
				.ForMember(vm => vm.Subject, opts => opts.MapFrom(dto => dto.Subject));

			this.CreateMap<TextLessMessageDTO, ShortMessageViewModel>()
				.ForMember(vm => vm.Id, opts => opts.MapFrom(dto => dto.Id))
				.ForMember(vm => vm.From, opts => opts.MapFrom(dto => dto.From))
				.ForMember(vm => vm.Subject, opts => opts.MapFrom(dto => dto.Subject));
		}
	}
}
