using AddressStandartization.Exceptions;
using System.Text;
using System.Text.Json;

namespace AddressStandartization.Services
{
	public class StandardizationService : IStandardizationService
	{
		private readonly IHttpClientFactory factory;

		public StandardizationService(IHttpClientFactory factory)
		{
			this.factory = factory;
		}

		public async Task<AddressModel> GetAddress(string address)
		{
			HttpClient client = factory.CreateClient("DadataApi");

			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
			request.Content = new StringContent($"[\"{address}\"]", Encoding.UTF8);

			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();

			var res = response.Content.ReadAsStringAsync().Result.Trim('[', ']');
			var standardizedResult = JsonSerializer.Deserialize<AddressModel>(res,
				new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true
				});

			ProcessServerException.ThrowIf(() => standardizedResult == null, "Не удалось получить стандартизованный адрес. Ошибка десериализации.");
			
			bool result = AddressModelValidator.Validate(standardizedResult!);
			ProcessException.ThrowIf(() => !result, 400, "Не удалось распознать адрес.");

			return standardizedResult!;
		}
	}
}
