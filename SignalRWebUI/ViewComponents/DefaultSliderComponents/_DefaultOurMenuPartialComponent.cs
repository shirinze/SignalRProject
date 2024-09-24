using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
	public class _DefaultOurMenuPartialComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpclientFactory;

        public _DefaultOurMenuPartialComponent(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Product");
            var jsonData=await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

      
	}
}
