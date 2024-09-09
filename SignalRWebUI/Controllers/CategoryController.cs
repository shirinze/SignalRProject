using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;

namespace SignalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;
        public CategoryController(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory; 
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
