﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.MessageDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

		public DefaultController(IHttpClientFactory httpclientFactory)
		{
			_httpclientFactory = httpclientFactory;
		}

		public async Task<IActionResult> Index()
        {
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync("https://localhost:7006/api/Contact");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.location = value;
			return View();
		}

        [HttpGet]
        public  PartialViewResult SendMessage()
        {  
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createmessagedto)
        {
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createmessagedto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7006/api/Message", stringcontent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
