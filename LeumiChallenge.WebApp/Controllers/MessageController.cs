using AutoMapper;
using LeumiChallenge.BusinessLogicLayer.Services;
using LeumiChallenge.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeumiChallenge.WebApp.Controllers
{
	public class MessageController : Controller
    {
		private readonly IMapper mapper;
		private readonly IMessageService service;

		public MessageController(IMapper mapper, IMessageService service)
		{
			this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
			this.service = service ?? throw new System.ArgumentNullException(nameof(service));
		}

		[HttpGet("[controller]/modal-details/{id}")]
        public IActionResult ModalDetails(int id)
        {
			var message = this.service.GetMessage(id);
			return PartialView("TextModalBody", this.mapper.Map<MessageViewModel>(message));
        }
    }
}