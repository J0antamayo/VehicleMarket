using Microsoft.EntityFrameworkCore;
using VehicleMarket.Models;

namespace VehicleMarket.AppDBContext
{
    public class VehicleMarketDbContext : DbContext
    {
        public VehicleMarketDbContext(DbContextOptions<VehicleMarketDbContext> options) : base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

    }
}
