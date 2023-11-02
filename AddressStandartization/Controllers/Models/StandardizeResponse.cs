

using AddressStandartization.Services;
using AutoMapper;

namespace AddressStandartization.Controllers.Models
{
	public class StandardizeResponse
	{
		public string Result { get; set; } = string.Empty;
	}

	public class StandardizeResponseProfile : Profile
	{
		public StandardizeResponseProfile()
		{
			CreateMap<AddressModel, StandardizeResponse>();
		}
	}
}
