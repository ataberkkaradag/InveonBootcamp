using LibraryManagement.Models;
using LibraryManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
    {

        
        public async Task<IActionResult> Index()
        {

            var users = await userManager.Users.ToListAsync();
            var userViewModelList = users.Select(x => new UserViewModel()
            {
                Id = x.Id,
                Email = x.Email!,
                UserName = x.UserName!
            }).ToList();
            return View(userViewModelList);
            
        }

        [HttpGet]
        
        public IActionResult Create() { return View(); }

        [HttpPost]
        
        public async Task<IActionResult> Create(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser 
                {
                    UserName = createUserViewModel.Username,
                    Email = createUserViewModel.Email,  

                };
                var result = await userManager.CreateAsync(user,createUserViewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("UserList","Admin");
                }


            }
            return RedirectToAction("Index");
        }

        [HttpGet]
       
        public async Task<IActionResult> UpdateUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("kullanıcı bulunamadı");
            }

            return View(new UserViewModel() {UserName=user.UserName,Email=user.Email});

        }
        [HttpPost]
       
        public async Task<IActionResult> UpdateUser(UserViewModel userModel)
        {
            var updateUser = await userManager.FindByIdAsync((userModel.Id).ToString());
            updateUser.Email = userModel.Email;
            updateUser.UserName = userModel.UserName;
            await userManager.UpdateAsync(updateUser);
            return RedirectToAction("UserList", "Admin");

        }

        
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            var result = await userManager.DeleteAsync(user!);
            return RedirectToAction("UserList", "Admin");

        }


        
    }
}
