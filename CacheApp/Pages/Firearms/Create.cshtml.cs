#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CacheApp.Authorization;
using CacheApp.Data;
using CacheApp.Models;

namespace CacheApp.Pages.Firearms
{
    public class CreateModel : BasePageModel
    {
        public CreateModel(CacheApp.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IActionResult OnGet()
        {
            var currentUserId = UserManager.GetUserId(User);
            ViewData["CaliberId"] = new SelectList(_context.Set<Caliber>()
                .Where(c => c.UserId == currentUserId), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Firearm Firearm { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Firearm.UserId = UserManager.GetUserId(User);
            
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Firearm,
                                                      Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            _context.Firearm.Add(Firearm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
