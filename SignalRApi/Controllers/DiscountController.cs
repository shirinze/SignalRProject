using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountservice;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountservice, IMapper mapper)
        {
            _discountservice = discountservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult DiscountList()
        {
            var value = _mapper.Map<List<ResultDiscountDto>>(_discountservice.TGetListAll());
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto creatediscountdto)
        {
            creatediscountdto.Status = false;
            var value = _mapper.Map<Discount>(creatediscountdto);
            _discountservice.TAdd(value);
            return Ok("basarili bir sekilde eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var value = _discountservice.TGetByID(id);
            _discountservice.TDelete(value);
            return Ok("basarili bir sekilde silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var value = _discountservice.TGetByID(id);
            return Ok(_mapper.Map<GetDiscountDto>(value));
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updatediscountdto)
        {
            updatediscountdto.Status = false;
            var value = _mapper.Map<Discount>(updatediscountdto);
            _discountservice.TUpdate(value);
            return Ok("basarili bir sekilde guncellendi");
        }
        [HttpGet("ChangeStatusToTrue/{id}")]

        public IActionResult ChangeStatusToTrue(int id)
        {
            _discountservice.TChangeStatusToTrue(id);
            return Ok("ürün indirimi aktif oldu");
        }
		[HttpGet("ChangeStatusToFalse/{id}")]

		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountservice.TChangeStatusToFalse(id);
			return Ok("ürün indirimi passif oldu");
		}
        [HttpGet("GetListByStatusTrue")]
        public IActionResult GetListByStatusTrue()
        {
            
            return Ok(_discountservice.TGetListByStatusTrue());
        }

	}
}
