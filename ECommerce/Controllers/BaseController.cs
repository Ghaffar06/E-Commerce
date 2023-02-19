using AppDbContext.Models;
using AppDbContext.UOW;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class BaseController : Controller
    {
        protected IUnitOfWork Uow { get; set; }
        protected IMapper Mapper { get; set; }
        protected UserManager<User> UserManager { get; set; }

        public BaseController(IUnitOfWork uow, IMapper mapper, UserManager<User> userManager)
        {
            this.Uow = uow;
            this.Mapper = mapper;
            this.UserManager = userManager;
        }

        protected async Task<string> GetCurrentUserId()
            => (await UserManager.GetUserAsync(HttpContext.User)).Id;


    }
}
