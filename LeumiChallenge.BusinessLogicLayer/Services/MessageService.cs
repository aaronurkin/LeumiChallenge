using AutoMapper;
using LeumiChallenge.BusinessLogicLayer.DataTransferObjects;
using LeumiChallenge.DataAccessLayer;
using Microsoft.Extensions.Logging;
using System;

namespace LeumiChallenge.BusinessLogicLayer.Services
{
	public class MessageService : IMessageService
	{
		private readonly IMapper mapper;
		private readonly MessageRepository repository;
		private readonly ILogger<MessageService> logger;

		public MessageService(
			IMapper mapper,
			MessageRepository repository,
			ILogger<MessageService> logger)
		{
			this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
			this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public virtual MessageDTO GetMessage(int id)
		{
			try
			{
				var message = this.repository.Find(id);
				return this.mapper.Map<MessageDTO>(message);
			}
			catch (Exception exception)
			{
				this.logger.LogError(exception, "Failed getting message {0}", id);
				throw exception;
			}
		}
	}
}
