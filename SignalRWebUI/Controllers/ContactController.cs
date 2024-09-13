using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpclientFactory;
        public ContactController(IHttpClientFactory httpclientFactory)
        {
			_httpclientFactory = httpclientFactory;
            
        }
        public async Task<IActionResult> Index()
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/Contact");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateContact()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateContact(CreateContactDto createcontactdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createcontactdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/Contact", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteContact(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7006/api/Contact/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updatecontactdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updatecontactdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/Contact", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
