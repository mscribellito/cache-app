#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CacheApp.Authorization;
using CacheApp.Data;
using CacheApp.Models;

namespace CacheApp.Pages.Calibers
{
    public class DetailsModel : BasePageModel
    {
        public DetailsModel(CacheApp.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public Caliber Caliber { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Caliber = await _context.Caliber.FirstOrDefaultAsync(m => m.Id == id);

            if (Caliber == null)
            {
                return NotFound();
            }
            
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Caliber,
                                                      Operations.Read);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            
            return Page();
        }
    }
}
