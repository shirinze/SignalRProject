using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : ControllerBase
	{
		private readonly IMenuTableService _menutableService;

		public MenuTableController(IMenuTableService menutableService)
		{
			_menutableService = menutableService;
		}
	
		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menutableService.TMenuTableCount());
		}
	}
}
