
namespace AddressStandartization.Services
{
	public class AddressModel
	{
		public string Result { get; set; } = string.Empty;
	}

	public static class AddressModelValidator
	{
		public static bool Validate(AddressModel model)
		{
			return !string.IsNullOrEmpty(model.Result);
		}
	}
}
