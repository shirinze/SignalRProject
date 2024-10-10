using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDdtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaPartialComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpclientfactory;

		public _UILayoutSocialMediaPartialComponent(IHttpClientFactory httpclientfactory)
		{
			_httpclientfactory = httpclientfactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpclientfactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/SocialMedia");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData=await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(value);
			}
			return View();
		}
	}
}
