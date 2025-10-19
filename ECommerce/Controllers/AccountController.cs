using ECommerce.DTOs;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> UserManager;
        public AccountController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }
        public IActionResult Login()
        {
            return View();

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            // Registration logic here (e.g., save user to database)
            if (ModelState.IsValid)
            {
                var userModel = new User
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FullName= user.FullName
                };
                var res =  await UserManager.CreateAsync(userModel,password:user.Password );
                if (res.Succeeded)
                {
                    await UserManager.AddToRoleAsync(userModel, user.Role);
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
    }
}
