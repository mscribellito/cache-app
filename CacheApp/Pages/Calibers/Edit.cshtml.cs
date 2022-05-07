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
using Microsoft.EntityFrameworkCore;
using CacheApp.Authorization;
using CacheApp.Data;
using CacheApp.Models;

namespace CacheApp.Pages.Calibers
{
    public class EditModel : BasePageModel
    {
        public EditModel(CacheApp.Data.ApplicationDbContext context,
            IAuthorizationService authorizationService,
            UserManager<IdentityUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
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
                                                      Operations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Caliber).State = EntityState.Modified;

            Caliber.UserId = UserManager.GetUserId(User);
            
            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                      User, Caliber,
                                                      Operations.Update);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaliberExists(Caliber.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CaliberExists(Guid id)
        {
            return _context.Caliber.Any(e => e.Id == id);
        }
    }
}
