#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CacheApp.Data;
using CacheApp.Models;

namespace CacheApp.Pages.Calibers
{
    public class DeleteModel : PageModel
    {
        private readonly CacheApp.Data.ApplicationDbContext _context;

        public DeleteModel(CacheApp.Data.ApplicationDbContext context)
        {
            _context = context;
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Caliber = await _context.Caliber.FindAsync(id);

            if (Caliber != null)
            {
                _context.Caliber.Remove(Caliber);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
