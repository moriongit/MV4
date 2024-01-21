using Cars.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cars.Context
{
    public class CarsDbContext : IdentityDbContext
    {
        public CarsDbContext(DbContextOptions opt) : base(opt)
        {
            
        }
        public DbSet<AutoAccessory> AutoAccessories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }    
    }
}
