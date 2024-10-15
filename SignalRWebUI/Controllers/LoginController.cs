using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signinmanager;

		public LoginController(SignInManager<AppUser> signinmanager)
		{
			_signinmanager = signinmanager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginDto logindto)
		{
			var result = await _signinmanager.PasswordSignInAsync(logindto.Username, logindto.Password, false, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			} 
		
			return View();
		}

		public async Task<IActionResult> LogOut()
		{
			await _signinmanager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
}
