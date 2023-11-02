using AddressStandartization.Middleware;
using Polly;
using Serilog;

namespace AddressStandartization.Configuration
{
	public static class HttpClientConfiguration
	{
		public static IServiceCollection AddAppHttpClient(this IServiceCollection services, DadataApiSettings settings)
		{
			services.AddHttpClient("DadataApi", (HttpClient client) =>
			{
				client.BaseAddress = new Uri(settings.URI);
			})
			.AddHttpMessageHandler<ApiHeadersMessageHandler>()
			.AddTransientHttpErrorPolicy(policy =>
				policy.WaitAndRetryAsync(new[] {
					TimeSpan.FromMilliseconds(200),
					TimeSpan.FromMilliseconds(500),
					TimeSpan.FromSeconds(1)
				}));

			return services;
		}
	}
}
