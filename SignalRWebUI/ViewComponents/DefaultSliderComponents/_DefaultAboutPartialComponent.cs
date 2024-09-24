using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.AboutDtos;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
    public class _DefaultAboutPartialComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpfactoryClient;

        public _DefaultAboutPartialComponent(IHttpClientFactory httpfactoryClient)
        {
            _httpfactoryClient = httpfactoryClient;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpfactoryClient.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/About");
            var jsondata=await responseMessage.Content.ReadAsStringAsync();
            var valus = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
            return View(valus);
        }
    }
}
