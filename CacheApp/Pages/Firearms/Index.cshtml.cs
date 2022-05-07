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

namespace CacheApp.Pages.Firearms
{
    public class IndexModel : PageModel
    {
        private readonly CacheApp.Data.ApplicationDbContext _context;

        public IndexModel(CacheApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Firearm> Firearm { get;set; }

        public async Task OnGetAsync()
        {
            Firearm = await _context.Firearm
                .Include(f => f.Caliber).ToListAsync();
        }
    }
}
