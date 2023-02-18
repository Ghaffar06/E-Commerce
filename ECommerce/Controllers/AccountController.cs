using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Customer")]
        public IActionResult onlyCustomer()
        {
            return Redirect(url: "https://localhost:44344/");
        }

        [HttpGet]
        [Authorize]
        [Authorize(Roles = "Admin")]
        public IActionResult onlyAdmin()
        {
            return Redirect(url: "https://localhost:44344/");
        }


        public async Task CreateRolesandUsers()
        {
            bool x = await _roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);
            }

            //Here we create a Admin super user who will maintain the website                   

            var user = new IdentityUser();
            user.UserName = "admin";
            user.Email = "admin@admin.com";
            string userPWD = "Admin1234!@#";

            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

            //Add default User to Role Admin    
            if (chkUser.Succeeded)
            {
                var result1 = await _userManager.AddToRoleAsync(user, "Admin");
            }

            // creating Creating Customer role     
            x = await _roleManager.RoleExistsAsync("Customer");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                await _roleManager.CreateAsync(role);
            }

            // creating Creating DeliveryEmployee role     
            x = await _roleManager.RoleExistsAsync("DeliveryEmployee");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "DeliveryEmployee";
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
