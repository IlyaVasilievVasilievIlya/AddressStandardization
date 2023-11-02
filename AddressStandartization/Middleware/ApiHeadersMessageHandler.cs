using AddressStandartization.Configuration;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Runtime;

namespace AddressStandartization.Middleware
{
	public class ApiHeadersMessageHandler : DelegatingHandler
	{
		DadataApiSettings _settings;

		public ApiHeadersMessageHandler(IOptions<DadataApiSettings> options) 
		{
			_settings = options.Value;
		}

		protected override async Task<HttpResponseMessage> SendAsync(
		HttpRequestMessage request,
		CancellationToken cancellationToken)
		{
			request.Headers.Add("Accept", _settings.Accept);
			request.Content.Headers.ContentType = new MediaTypeHeaderValue(_settings.Content_Type);
			request.Headers.Authorization = new AuthenticationHeaderValue("Token", _settings.Api_Key);
			request.Headers.Add("X-Secret", _settings.Secret);
			HttpResponseMessage response =
				await base.SendAsync(request, cancellationToken);
			return response;
		}

	}
}
