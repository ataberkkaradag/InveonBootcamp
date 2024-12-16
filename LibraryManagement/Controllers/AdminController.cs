using LibraryManagement.Models;
using LibraryManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager) : Controller
    {
       
        public async Task<IActionResult> UserList()
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

        
        public async Task<IActionResult> RoleList()
        {
            var roles = await roleManager.Roles.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            
            return View(roles); 
        }
    }
}
