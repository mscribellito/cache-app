using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CacheApp.Data;

namespace CacheApp.Pages
{

    public class BasePageModel : PageModel
    {

        protected ApplicationDbContext _context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<IdentityUser> UserManager { get; }

        public BasePageModel(
            ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager) : base()
        {
            _context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }

    }

}