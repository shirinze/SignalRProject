using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BuinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingservice;
        private readonly IMapper _mapper;
        public BookingController(IBookingService bookingservice, IMapper mapper)
        {
            _bookingservice = bookingservice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingservice.TGetListAll();
            return Ok(_mapper.Map<List<ResultBookingDto>>(values));
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createbookingdto)
        {
            var value = _mapper.Map<Booking>(createbookingdto);

            _bookingservice.TAdd(value);
            return Ok("rezervasyon başarili bir şekilde eklendi");


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingservice.TGetByID(id);
            _bookingservice.TDelete(value);
            return Ok("rezervasyon başarili bir şekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updatebookingdto)
        {
            var value = _mapper.Map<Booking>(updatebookingdto);

            _bookingservice.TUpdate(value);
            return Ok("rezervasyon başarili bir şekilde güncellendi");
        }

        [HttpGet("{id}")]

        public IActionResult GetBooking(int id)
        {
            var value = _bookingservice.TGetByID(id);
            return Ok(_mapper.Map<GetBookingDto>(value));
        }
        [HttpGet("BookingStatusApprove/{id}")]
        public IActionResult BookingStatusApprove(int id)
        {
            _bookingservice.TBookingStatusApprove(id);
            return Ok("rezervasyon açıklaması değiştirildi");
        }
		[HttpGet("BookingStatusCancel/{id}")]
		public IActionResult BookingStatusCancel(int id)
		{
			_bookingservice.TBookingStatusCancel(id);
			return Ok("rezervasyon açıklaması değiştirildi");
		}

	}
}
