using System.Reflection;

namespace AddressStandartization.Configuration
{
	public static class AutoMapperConfiguration
	{
		public static IServiceCollection AddAppAutoMappers(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
