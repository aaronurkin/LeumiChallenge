using LeumiChallenge.BusinessLogicLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeumiChallenge.BusinessLogicLayer.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddBusinessLogic(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<DataAccessLayer.LeumiChallengeDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("LeumiChallengeDb"));
			});

			var provider = services.BuildServiceProvider();
			var database = provider.GetService<DataAccessLayer.LeumiChallengeDbContext>();

			services.AddTransient(s => new DataAccessLayer.MessageRepository(database));
			services.AddTransient(s => new DataAccessLayer.CustomerRepository(database));
			services.AddTransient<IMessageService, MessageService>();
			services.AddTransient<ICustomerService, CustomerService>();

			return services;
		}
	}
}
