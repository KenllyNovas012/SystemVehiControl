using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using SystemVehiControl.Models;

namespace SystemVehiControl.ApplicationContext
{
    public class VehixControlContext : DbContext
    {
        public VehixControlContext(DbContextOptions<VehixControlContext> options) : base(options) { }
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ExteriorInspection> ExteriorInspections { get; set; }
        public DbSet<InteriorInspection> InteriorInspections { get; set; }
        public DbSet<NCF> NCFs { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationDetail> QuotationDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }
        public DbSet<ServiceCase> ServiceCases { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<StockEntry> StockEntries { get; set; }
        public DbSet<StockEntryDetail> StockEntryDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleReception> VehicleReceptions { get; set; }

        // Puedes sobreescribir OnModelCreating si necesitas configuraciones específicas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ejemplo de configuración adicional si necesitas claves compuestas, restricciones, etc.
            // modelBuilder.Entity<QuotationDetail>()
            //     .HasKey(qd => new { qd.QuotationId, qd.ArticleId });
        }
    }
}
