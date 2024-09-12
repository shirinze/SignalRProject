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
        public BookingController(IBookingService bookingservice)
        {
            _bookingservice = bookingservice;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingservice.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createbookingdto)
        {
            Booking booking = new Booking()
            { 
                Name=createbookingdto.Name,
                Phone=createbookingdto.Phone,
                Mail=createbookingdto.Mail,
                PersonCount=createbookingdto.PersonCount,
                Date=createbookingdto.Date
            };

            _bookingservice.TAdd(booking);
            return Ok("rezervasyon basarili bir sekilde eklendi");


        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingservice.TGetByID(id);
            _bookingservice.TDelete(value);
            return Ok("rezervasyon basarili bir sekilde silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updatebookingdto)
        {
            Booking booking = new Booking()
            {
                BookingID=updatebookingdto.BookingID,
                Name=updatebookingdto.Name,
                Phone=updatebookingdto.Phone,
                Mail=updatebookingdto.Mail,
                PersonCount=updatebookingdto.PersonCount,
                Date=updatebookingdto.Date
            };

            _bookingservice.TUpdate(booking);
            return Ok("rezervasyon basarili bir sekilde guncellendi");
        }

        [HttpGet("{id}")]

        public IActionResult GetBooking(int id)
        {
            var value = _bookingservice.TGetByID(id);
            return Ok(value);
        }
    }
}
