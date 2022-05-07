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

namespace CacheApp.Pages.Firearms
{
    public class IndexModel : BasePageModel
    {
        public IndexModel(CacheApp.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<Firearm> Firearm { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);
            Firearm = await _context.Firearm
                .Include(f => f.Caliber)
                .Where(f => f.UserId == currentUserId)
                .ToListAsync();
        }
    }
}
