#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; } 

        public const int PageSize = 20;

        public PaginatedList<Caliber> Calibers { get; set; }

        public async Task OnGetAsync()
        {
            var currentUserId = UserManager.GetUserId(User);

            IQueryable<Caliber> calibers = from c in _context.Caliber
                .Where(c => c.UserId == currentUserId)
                .OrderBy(SortBy + " descending")
                select c;

            Calibers = await PaginatedList<Caliber>.CreateAsync(
                calibers.AsNoTracking(), CurrentPage, PageSize);
        }
    }
}
