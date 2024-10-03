using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

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

		[HttpGet]
		public IActionResult MenuTableList()
		{
			var values = _menutableService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createmenutabledto)
		{
			MenuTable menutable = new MenuTable()
			{
				Status = false,
				Name = createmenutabledto.Name,
			
			};
			_menutableService.TAdd(menutable);
			return Ok("basarili bir sekilde eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menutableService.TGetByID(id);
			_menutableService.TDelete(value);
			return Ok("basari bir sekilde silindi");
		}
		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updatemenutabledto)
		{
			MenuTable menuTable = new MenuTable
			{
				MenuTableID = updatemenutabledto.MenuTableID,
				Name = updatemenutabledto.Name,
				Status = false,
			
			};
			_menutableService.TUpdate(menuTable);
			return Ok("guncellemdi");
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var value = _menutableService.TGetByID(id);
			return Ok(value);
		}
	}
}
