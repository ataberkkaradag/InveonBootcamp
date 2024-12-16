using LibraryManagement.Models;
using LibraryManagement.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibraryManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager): Controller
    {
        public  async Task<IActionResult> Index()
        {
            var roles=await roleManager.Roles.Select(x=>new RoleViewModel()
            {
                Id = x.Id,
                Name=x.Name!
            }).ToListAsync();

           
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create() { return View(); }

        [HttpPost]
        public async Task<IActionResult> Create(string name) 
        {
            if (ModelState.IsValid)
            {
                var role = new AppRole { Name = name };
                var result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("RoleList","Admin");
                }
                

            }
            return View(name);
        }

            [HttpGet]
            public async Task<IActionResult> RoleUpdate(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Rol kimliği boş olamaz.");
            }
            var role=await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                throw new Exception("rol bulunamadı");
            }

            return View(new RoleViewModel() { Id=role.Id,Name=role.Name!});

        }
        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleViewModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                return View(roleModel);
            }
            var updateRole = await roleManager.FindByIdAsync((roleModel.Id).ToString());
            updateRole.Name = roleModel.Name;   
            await roleManager.UpdateAsync(updateRole);
            return RedirectToAction("RoleList", "Admin");

        }

        public async Task<IActionResult> DeleteRole(string id)
        {

            var role= await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound("Silinecek rol bulunamadı.");
            }

            var result =await roleManager.DeleteAsync(role!);
            return RedirectToAction("RoleList", "Admin");

        }






        [HttpGet]
        public async Task<IActionResult> AssignRoleToUser(string id)
        {
            var currentUser = (await userManager.FindByIdAsync(id))!;
            if (currentUser == null)
            {
                return NotFound("Kullanıcı bulunamadı.");
            }
            ViewBag.userId = id;
            var roles = await roleManager.Roles.ToListAsync();
            var userRoles = await userManager.GetRolesAsync(currentUser);
            var roleViewModelList = new List<AssignRoleViewModel>();

            foreach (var role in roles)
            {

                var assignRoleToUserViewModel = new AssignRoleViewModel() { Id = role.Id, Name = role.Name!,IsSelected=userRoles.Contains(role.Name) };

                roleViewModelList.Add(assignRoleToUserViewModel);

            }

            return View(roleViewModelList);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(string userId, List<AssignRoleViewModel> requestList)
        {

            var userToAssignRoles = (await userManager.FindByIdAsync(userId))!;

            foreach (var role in requestList)
            {
 
                 if (role.IsSelected)
                 {
                    await userManager.AddToRoleAsync(userToAssignRoles, role.Name);
                }
                else
                 {
                     await userManager.RemoveFromRoleAsync(userToAssignRoles, role.Name);
                 }

            }

            return RedirectToAction("Index","User");
        }



    }
}
