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
            _discountservice.TAdd(new Discount()
            {
              Title=creatediscountdto.Title,
              Amount=creatediscountdto.Amount,
              Description=creatediscountdto.Description,
              ImageUrl=creatediscountdto.ImageUrl

            });
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
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updatediscountdto)
        {
            _discountservice.TUpdate(new Discount()
            {
                DiscountID = updatediscountdto.DiscountID,
                Title = updatediscountdto.Title,
                Amount = updatediscountdto.Amount,
                Description = updatediscountdto.Description,
                ImageUrl = updatediscountdto.ImageUrl

            });
            return Ok("basarili bir sekilde guncellendi");
        }
    }
}
