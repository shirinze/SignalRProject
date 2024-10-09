using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class SliderController : Controller
	{
		private readonly IHttpClientFactory _httpclientFactory;
        public SliderController(IHttpClientFactory httpclientFactory)
        {
			_httpclientFactory = httpclientFactory;
        }
        public async Task<IActionResult> Index()
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/Slider");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateSlider()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSlider(CreateSliderDto createsliderdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createsliderdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/Slider", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteSlider(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/Slider/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateSlider(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7006/api/Slider/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSlider(UpdateSliderDto updatesliderdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatesliderdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/Slider", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
