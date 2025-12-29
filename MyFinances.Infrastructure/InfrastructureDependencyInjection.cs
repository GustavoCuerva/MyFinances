using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFinances.Infrastructure.Database;

namespace MyFinances.Infrastructure;

public static class InfrastructureDependencyInjection
{
	public static IServiceCollection AddInfrastructureServices(
		this IServiceCollection services,
		string connectionStringSqlServer
		)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionStringSqlServer)
		);

		return services;
	}
}