using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.TestimonialDtos;

namespace SignalRWebUI.ViewComponents.DefaultSliderComponents
{
    public class _DefaultTestimonialPartialComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public _DefaultTestimonialPartialComponent(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync()
        {
            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Testimonial");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
    }
}
