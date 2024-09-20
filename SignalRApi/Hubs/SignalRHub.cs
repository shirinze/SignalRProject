using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;
using SignalR.BuinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

		public SignalRHub(ICategoryService categoryService, IProductService productService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		public async Task SendStatistic()
		{
			var values1 = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("RecieveCategoryCount", values1);

			var values2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceievProductCount", values2);

			var values3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", values3);

			var values4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", values4);

			var values5 = _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", values5);

			var values6 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", values6);

			var values7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", values7);

			var values8 = _productService.TProductNameMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameMaxPrice", values8);

			var values9 = _productService.TProductNameMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameMinPrice", values9);

			var values10 = _productService.TProductPriceByHmaburger();
			await Clients.All.SendAsync("ReceiveProductPriceByHmaburger", values10);
		}
	
	}
}
