using AddressStandartization.Controllers.Models;
using AddressStandartization.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.Text;

namespace AddressStandartization.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AddressController : ControllerBase
	{
		private readonly IMapper mapper;
		private readonly ILogger<AddressController> logger;
		private readonly IStandardizationService standardizationService;

		public AddressController(ILogger<AddressController> logger, IStandardizationService standardizationService, IMapper mapper)
		{
			this.logger = logger;
			this.standardizationService = standardizationService;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<StandardizeResponse> Get([FromQuery] string address)
		{
			var standardizedAddress = await standardizationService.GetAddress(address);
			var response = mapper.Map<StandardizeResponse>(standardizedAddress);

			return response;
		}
	}
}