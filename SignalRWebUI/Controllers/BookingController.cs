using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpclientFactory;
        public BookingController(IHttpClientFactory httpclientFactory)
        {
			_httpclientFactory = httpclientFactory;
        }
        public async Task<IActionResult> Index()
		{
			var client = _httpclientFactory.CreateClient();
			var responseMassage = await client.GetAsync("https://localhost:7006/api/Booking");
			if (responseMassage.IsSuccessStatusCode)
			{
				var jsonData=await responseMassage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateBooking()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateBooking(CreateBookingDto createbookingdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createbookingdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/Booking", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteBooking(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/Booking/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateBooking(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7006/api/Booking/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(values);
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updatebookingdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatebookingdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/Booking", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
