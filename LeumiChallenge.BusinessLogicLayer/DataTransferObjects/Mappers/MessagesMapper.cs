using AutoMapper;
using LeumiChallenge.DataAccessLayer;

namespace LeumiChallenge.BusinessLogicLayer.DataTransferObjects.Mappers
{
	public class MessagesMapper : Profile
	{
		public MessagesMapper()
		{
			this.CreateMap<Message, TextLessMessageDTO>()
				.ForMember(dto => dto.Id, opts => opts.MapFrom(source => source.MessageId))
				.ForMember(dto => dto.From, opts => opts.MapFrom(source => source.MessageFrom))
				.ForMember(dto => dto.Subject, opts => opts.MapFrom(source => source.MessageSubject));

			this.CreateMap<Message, MessageDTO>()
				.ForMember(dto => dto.Id, opts => opts.MapFrom(source => source.MessageId))
				.ForMember(dto => dto.From, opts => opts.MapFrom(source => source.MessageFrom))
				.ForMember(dto => dto.Text, opts => opts.MapFrom(source => source.MessageText))
				.ForMember(dto => dto.CustomerId, opts => opts.MapFrom(source => source.CustomerId))
				.ForMember(dto => dto.Subject, opts => opts.MapFrom(source => source.MessageSubject));
		}
	}
}
