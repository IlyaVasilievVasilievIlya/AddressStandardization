namespace AddressStandartization.Services
{
	public interface IStandardizationService
	{
		Task<AddressModel> GetAddress(string address);
	}
}
