using ECommerce.DTOs;
using ECommerce.Models;
using ECommerce.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> UserManager;
        private readonly SignInManager<User> SignInManager;
        private readonly RoleRepository RoleRepository;

        public AccountController(
            UserManager<User> userManager,
            RoleRepository roleRepository,
            SignInManager<User> signInManager)
        {
            UserManager = userManager;
            RoleRepository = roleRepository;
            SignInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO user)
        {
            if (ModelState.IsValid)
            {
                //search for user by user name or email
                var User = await UserManager.FindByNameAsync(user.Text);
                //found User By Username
                if (User == null)
                {
                    //found User By Email

                   User = await UserManager.FindByEmailAsync(user.Text);
                }
                if(User == null)
                {
                    ModelState.AddModelError("", "Sorry Register First or Ensure Of Account Inforamtion");
                    return View();
                }
                var SignInResult = await SignInManager.PasswordSignInAsync(User, user.Password, user.RememberMe, lockoutOnFailure: true);

                if (SignInResult.Succeeded)
                {
                    /////////////////////////////////////
                    return RedirectToAction("Index", "Home");
                }
                else if (SignInResult.IsLockedOut || SignInResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Your Account is Under Reviw Will Connet with you Later Stay tunned");
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name Or Password");
                    return View();
                }



               

            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = GetAllRolea();
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
                else
                {
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            
            ViewBag.Roles = GetAllRolea();
            return View();
        }



        private List<SelectListItem> GetAllRolea()
        {
            return RoleRepository.GetAll ().Select(r=>new SelectListItem{ Text=r.Name,Value=r.Name} ).ToList();
        }
    }
}
