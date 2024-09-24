using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.ContactDtos;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterPartialComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _UILayoutFooterPartialComponent(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var clients = _httpclientFactory.CreateClient();
            var responseMessage = await clients.GetAsync("https://localhost:7006/api/Contact");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
            return View(values);
        }
    }
}
