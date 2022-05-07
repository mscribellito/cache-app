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
using CacheApp.Data;
using CacheApp.Models;

namespace CacheApp.Pages.Calibers
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(CacheApp.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<Caliber> Caliber { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            Caliber = await _context.Caliber
                .Where(c => c.UserId == currentUserId)
                .ToListAsync();
        }
    }
}
