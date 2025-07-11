using Microsoft.EntityFrameworkCore;
using SolidProducts.Entities;

namespace SolidProducts.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>().HasQueryFilter(p => p.DeletedAt == null);
            modelBuilder.Entity<ProductGroup>().HasQueryFilter(pg => pg.DeletedAt == null);
            modelBuilder.Entity<Manufacturer>().HasQueryFilter(m => m.DeletedAt == null);
            modelBuilder.Entity<Supplier>().HasQueryFilter(s => s.DeletedAt == null);

      
            modelBuilder.Entity<Product>(b =>
                {
                    b.Property(p => p.Price)
                    .HasPrecision(18, 2);

                    b.Property(p => p.Weight)
                    .HasPrecision(18, 3);
                }
            );

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Manufacturer).WithMany().HasForeignKey(p => p.ManufacturerId);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier).WithMany().HasForeignKey(p => p.SupplierId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
