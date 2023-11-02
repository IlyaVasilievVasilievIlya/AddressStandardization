

using AddressStandartization.Services;

namespace AddressStandartization.Configuration
{
	public static class ServicesConfiguration
	{
		public static IServiceCollection AddStandardizationService(this IServiceCollection services)
		{
			services.AddSingleton<IStandardizationService, StandardizationService>();

			return services;
		}
	}
}
