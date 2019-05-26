using AutoMapper;
using LeumiChallenge.BusinessLogicLayer.Services;
using LeumiChallenge.Common;
using LeumiChallenge.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LeumiChallenge.WebApp.Controllers
{
	public class CustomerController : Controller
    {
		private readonly IMapper mapper;
		private readonly ICustomerService service;

		public CustomerController(IMapper mapper, ICustomerService service)
		{
			this.mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
			this.service = service ?? throw new System.ArgumentNullException(nameof(service));
		}

		public IActionResult List()
        {
			var customers = this.service.GetCustomersPage(1, 5);
			return View(this.mapper.Map<PagedList<CustomerViewModel>>(customers));
		}

		public IActionResult Details(int id)
        {
			var customer = this.service.GetCustomerDetails(id);
			return View(this.mapper.Map<CustomerViewModel>(customer));
		}
	}
}