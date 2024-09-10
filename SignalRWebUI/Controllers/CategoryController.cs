using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using System.Text;

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

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createcategorydto)
        {
            createcategorydto.CategoryStatus = true;
            var client = _httpclientfactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createcategorydto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7006/api/Category",stringcontent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/Category/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var client = _httpclientfactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7006/api/Category/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updatecategorydto)
        {
            var client = _httpclientfactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatecategorydto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7006/api/Category/", stringcontent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
