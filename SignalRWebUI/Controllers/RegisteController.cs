using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisteController : Controller
    {
        private readonly UserManager<AppUser> _usermanager;

        public RegisteController(UserManager<AppUser> usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerdto)
        {
            AppUser appuser=new AppUser()           
            { 
                Name=registerdto.Name,
                Surname=registerdto.Surname,
                Email=registerdto.Mail,
                UserName=registerdto.Username
            
            };
            var result = await _usermanager.CreateAsync(appuser, registerdto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
