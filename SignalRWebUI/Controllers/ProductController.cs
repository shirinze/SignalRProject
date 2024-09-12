using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpclientFactory;
        public ProductController(IHttpClientFactory httpclientFactory)
        {
			_httpclientFactory = httpclientFactory;
        }
        public async Task<IActionResult> Index()
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7006/api/Product/ProductListWithCategory");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var client = _httpclientFactory.CreateClient();
			var respnseMessage = await client.GetAsync("https://localhost:7006/api/Category");
			var jsonData = await respnseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
			List<SelectListItem> values2 = (from x in values
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryID.ToString()
											}).ToList();
			ViewBag.v = values2;
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateProduct(CreateProductDto createproductdto)
		{
			createproductdto.ProductStatus = true;
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createproductdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7006/api/Product", stringcontent);
			if(responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteProduct(int id)
		{
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7006/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> UpdateProduct(int id)
		{
			var client1 = _httpclientFactory.CreateClient();
			var respnseMessage1 = await client1.GetAsync("https://localhost:7006/api/Category");
			var jsonData1 = await respnseMessage1.Content.ReadAsStringAsync();
			var values1 = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData1);
			List<SelectListItem> values2 = (from x in values1
											select new SelectListItem
											{
												Text = x.CategoryName,
												Value = x.CategoryID.ToString()
											}).ToList();
			ViewBag.v = values2;
			var client = _httpclientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7006/api/Product/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateproductdto)
		{
			var client = _httpclientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateproductdto);
			StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7006/api/Product", stringcontent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
