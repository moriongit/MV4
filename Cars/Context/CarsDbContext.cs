using Cars.Models;
using Microsoft.EntityFrameworkCore;

namespace Cars.Context
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions opt) : base(opt)
        {
            
        }
        public DbSet<AutoAccessory> AutoAccessories { get; set; }
    }
}
