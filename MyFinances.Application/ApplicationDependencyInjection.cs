using Microsoft.Extensions.DependencyInjection;

namespace MyFinances.Application;

public static class ApplicationDependencyInjection
{
	public static IServiceCollection AddApplicationService(this IServiceCollection services)
	{
		return services;
	}
}
