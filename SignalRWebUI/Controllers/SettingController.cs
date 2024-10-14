using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class SettingController : Controller
	{
		private readonly UserManager<AppUser> _usermanager;

		public SettingController(UserManager<AppUser> usermanager)
		{
			_usermanager = usermanager;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _usermanager.FindByNameAsync(User.Identity.Name);
			UserEditDto usereditDto = new UserEditDto();
			usereditDto.SureName = values.Surname;
			usereditDto.Name = values.Name;
			usereditDto.Username = values.UserName;
			usereditDto.Mail = values.Email;
			return View(usereditDto);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditDto usereditdto)
		{
			if (usereditdto.Password == usereditdto.ConfirmPassword)
			{
				var user = await _usermanager.FindByNameAsync(User.Identity.Name);
				user.Name = usereditdto.Name;
				user.Surname = usereditdto.SureName;
				user.Email = usereditdto.Mail;
				user.UserName = usereditdto.Username;
				user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, usereditdto.Password);
				await _usermanager.UpdateAsync(user);
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
	}
}
