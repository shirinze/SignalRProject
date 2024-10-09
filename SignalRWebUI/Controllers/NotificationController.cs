using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.NotificationDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class NotificationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/Notification");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateNotification()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto createnotificationdto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createnotificationdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/Notification", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/Notification/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7006/api/Notification/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updatentificationdto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatentificationdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/Notification", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> NotificationstatusChangetoTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7006/api/Notification/NotificationStatusChangetoTrue/{id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> NotificationstatusChangetoFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7006/api/Notification/NotificationStatusChangetoFalse/{id}");
			return RedirectToAction("Index");
		}
	}
}
