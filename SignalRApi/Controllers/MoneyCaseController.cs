using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCaseController : ControllerBase
	{
		private readonly IMoneyCaseService _moneycaseService;

		public MoneyCaseController(IMoneyCaseService moneycaseService)
		{
			_moneycaseService = moneycaseService;
		}
		[HttpGet("TotalMoneyCaseAmount")]
		public IActionResult TotalMoneyCaseAmount()
		{
			return Ok(_moneycaseService.TTotalMoneyCaseAmount());
		}
	}
}
