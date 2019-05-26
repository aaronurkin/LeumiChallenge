using LeumiChallenge.BusinessLogicLayer.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeumiChallenge.BusinessLogicLayer.Services
{
	public interface IMessageService
	{
		MessageDTO GetMessage(int id);
	}
}
