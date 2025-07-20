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
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientGroup> ClientGroups { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<PaymentCondition> PaymentConditions { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasQueryFilter(p => p.DeletedAt == null);
            modelBuilder.Entity<ProductGroup>().HasQueryFilter(pg => pg.DeletedAt == null);
            modelBuilder.Entity<Product>().HasQueryFilter(m => m.DeletedAt == null);
            modelBuilder.Entity<Client>().HasQueryFilter(s => s.DeletedAt == null);
            modelBuilder.Entity<ClientGroup>().HasQueryFilter(cg => cg.DeletedAt == null);
            modelBuilder.Entity<Invoice>().HasQueryFilter(i => i.DeletedAt == null);
            modelBuilder.Entity<InvoiceDetail>().HasQueryFilter(id => id.DeletedAt == null);
            modelBuilder.Entity<PaymentCondition>().HasQueryFilter(pc => pc.DeletedAt == null);
            modelBuilder.Entity<Warehouse>().HasQueryFilter(w => w.DeletedAt == null);

            // Apply to all entities that inherit from BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAt")
                    .HasDefaultValueSql("GETUTCDATE()");
            }
            // modelBuilder.Entity<Product>(b =>
            //     {
            //         b.Property(p => p.Price)
            //         .HasPrecision(18, 2);

            //         b.Property(p => p.Weight)
            //         .HasPrecision(18, 3);
            //     }
            // );

            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.Manufacturer).WithMany().HasForeignKey(p => p.ManufacturerId);

            // modelBuilder.Entity<Product>()
            //     .HasOne(p => p.Supplier).WithMany().HasForeignKey(p => p.SupplierId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
