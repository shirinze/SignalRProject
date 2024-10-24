using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.DtoLayer.MenuTableDto;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public MenuController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v = id; 

            var client = _httpclientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7006/api/Product/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id,int menuTableId)
        {
            if (menuTableId == 0)
            {
                return BadRequest("MenuTableId 0 geliyor");

            }
            CreateBasketDto createbasketdto = new CreateBasketDto
            {
                ProductID = id,
                MenuTableID = menuTableId

            };
            
            var client = _httpclientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createbasketdto);
            StringContent stringcontent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7006/api/Basket", stringcontent);

            var client2 = _httpclientFactory.CreateClient();
            await client2.GetAsync("https://localhost:7006/api/MenuTable/ChangeMenuTableStatusToTrue?id=" + menuTableId);
     
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createbasketdto);
        }
    }
}
