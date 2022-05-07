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
    public class IndexModel : PageModel
    {
        private readonly CacheApp.Data.ApplicationDbContext _context;

        public IndexModel(CacheApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Caliber> Caliber { get;set; }

        public async Task OnGetAsync()
        {
            Caliber = await _context.Caliber.ToListAsync();
        }
    }
}
