using LoadMeasurementPanel.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoadMeasurementPanel.Infra.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<MeasuringPoint> MeasuringPoints { get; set; }
        public DbSet<EnergyConsumptionPerDay> EnergyConsumptionsPerDay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
