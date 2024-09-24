using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.DiscountDtos;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
    public class _DefaultOfferPartialComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Discount");
            var json = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(json);
            return View(value);
        }
    }
}
