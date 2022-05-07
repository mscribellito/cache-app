using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CacheApp.Models;

namespace CacheApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<CacheApp.Models.Firearm> Firearm { get; set; }
    public DbSet<CacheApp.Models.Caliber> Caliber { get; set; }
}
