﻿using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;
using SignalR.BuinessLayer.Abstract;
using SignalR.DataAccessLayer.Concreate;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneycaseService;
		private readonly IMenuTableService _menutableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneycaseService, IMenuTableService menutableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneycaseService = moneycaseService;
			_menutableService = menutableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
		public static int clientCount { get; set; } = 0;
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
			await Clients.All.SendAsync("ReceiveProductPriceAvg", values7.ToString("0.00" + "₺"));

			var values8 = _productService.TProductNameMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameMaxPrice", values8);

			var values9 = _productService.TProductNameMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameMinPrice", values9);

			var values10 = _productService.TProductPriceByHmaburger();
			await Clients.All.SendAsync("ReceiveProductPriceByHmaburger", values10.ToString("0.00" + "₺"));

			var values11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", values11);

			var values12 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount",values12);

			var values13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", values13.ToString("0.00" + "₺"));

			var values14 = _moneycaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", values14.ToString("0.00" + "₺"));

			var values16 = _menutableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", values16);
		}
		public async Task SendProgress()
		{
			var value = _moneycaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00")+"₺");

			var value1 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value1);

			var value2 = _menutableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value2);

			var value3 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", value3);

			var value4 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value4);

			var value5 = _productService.TProductPriceByHmaburger();
			await Clients.All.SendAsync("ReceiveProductPriceByHmaburger", value5);

			var value6 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value6);

			var value7 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value7);


            var value8 = _productService.TTotalPriceByDrinkCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value8);


            var value9 = _productService.TTotalPriceBySaladCategory();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value9);


        }
		public async Task GetBookingList()
		{
			var values=_bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}
		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

			var value1 = _notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveAllNotificationByFalse", value1);
		}

		public async Task GetMenuTable()
		{
			var value = _menutableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}

		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
        public override async Task OnConnectedAsync()
        {
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnDisconnectedAsync(exception);
        }


    }
}
