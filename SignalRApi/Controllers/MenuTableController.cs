using AutoMapper;
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
		private readonly IMapper _mapper;

        public MenuTableController(IMenuTableService menutableService, IMapper mapper)
        {
            _menutableService = menutableService;
            _mapper = mapper;
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
			return Ok(_mapper.Map<List<ResultMenuTableDto>>(values));
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createmenutabledto)
		{
			createmenutabledto.Status = false;
			var vale = _mapper.Map<MenuTable>(createmenutabledto);
			_menutableService.TAdd(vale);
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
			updatemenutabledto.Status = false;
			var value = _mapper.Map<MenuTable>(updatemenutabledto);
			_menutableService.TUpdate(value);
			return Ok("guncellemdi");
		}
		[HttpGet("{id}")]
		public IActionResult GetAbout(int id)
		{
			var value = _menutableService.TGetByID(id);
			return Ok(_mapper.Map<GetMenuTableDto>(value));
		}
		[HttpGet("ChangeMenuTableStatusToFalse")]
		public IActionResult ChangeMenuTableStatusToFalse(int id)
		{
			_menutableService.TChangeMenuTableStatusToFalse(id);
			return Ok("işlem başarılı");
		}
		[HttpGet("ChangeMenuTableStatusToTrue")]
		public IActionResult ChangeMenuTableStatusToTrue(int id)
		{
			_menutableService.TChangeMenuTableStatusToTrue(id);
			return Ok("işlem başarılı");
		}
    }
}
