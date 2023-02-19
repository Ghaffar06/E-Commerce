using AppDbContext.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> userManager,
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
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> TESTing()
        {
            User user = await _userManager.GetUserAsync(HttpContext.User);
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

            var user = new User();
            user.UserName = "admin";
            user.Email = "admin@admin.com";
            user.Role = "Admin";
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

			// creating Creating Deliverer role     
			x = await _roleManager.RoleExistsAsync("Deliverer");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Deliverer";
                await _roleManager.CreateAsync(role);
            }
        }
    }
}
