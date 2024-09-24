using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
    public class _DefaultSliderPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _DefaultSliderPartialComponent(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Slider");
            var json = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(json);
            return View(values);


        }
    }
}
