using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _httpclientFactory;
        public AboutController(IHttpClientFactory httpclientFactory)
        {
			_httpclientFactory = httpclientFactory;
        }
		
        public async Task<IActionResult> Index()
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/About");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateAbout()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateAbout(CreateAboutDto createaboutdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createaboutdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/About", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteAbout(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/About/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateAbout(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7006/api/About/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateaboutdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateaboutdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/About", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
