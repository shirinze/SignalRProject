using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concreate;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		SignalRContext context = new SignalRContext();
		public async Task SendCategoryCount()
		{
			var values = context.Categories.Count();
			await Clients.All.SendAsync("RecieveCategoryCount", values);
		}
	}
}
