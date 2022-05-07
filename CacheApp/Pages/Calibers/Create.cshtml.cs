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

namespace CacheApp.Pages.Calibers
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
            return Page();
        }

        [BindProperty]
        public Caliber Caliber { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Caliber.UserId = UserManager.GetUserId(User);
            
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Caliber,
                                                      Operations.Create);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            _context.Caliber.Add(Caliber);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
