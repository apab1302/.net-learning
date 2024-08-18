using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Vehicles.Models;

namespace Vehicles
{
    public class VehiclesDbContext: DbContext
    {
      public  DbSet <Vehicle> Vehicles { get; set; }

        public VehiclesDbContext(DbContextOptions<VehiclesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
