using Microsoft.EntityFrameworkCore;
using VehicleMarket.Models;

namespace VehicleMarket.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

    }
}
