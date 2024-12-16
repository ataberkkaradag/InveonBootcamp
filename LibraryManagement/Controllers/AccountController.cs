using LibraryManagement.Models;
using LibraryManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LibraryManagement.Controllers
{
    public class AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }
                var user = new  AppUser{ UserName = userModel.Username,Email=userModel.Email};
            var result = await userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(userModel);
        }


        [HttpGet("login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }


        [HttpPost("login")]
        
        public async Task<IActionResult> Login(LoginUserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel); 
            }


            var result = await signInManager.PasswordSignInAsync(userModel.Username,userModel.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        
        public async Task<IActionResult> ProfileDetails()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                return Unauthorized("User is not authenticated.");
            }


            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            
            var model = new UserProfileViewModel
            {
                UserName = user.UserName!,
                Email = user.Email!,

            };

            return View(model);
        }
    }
}
