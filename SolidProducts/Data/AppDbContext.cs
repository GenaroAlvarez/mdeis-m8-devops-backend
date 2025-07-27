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
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }

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
            modelBuilder.Entity<DocumentType>().HasQueryFilter(dt => dt.DeletedAt == null);
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.IsSubclassOf(typeof(BaseEntity))))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .Property("CreatedAt")
                    .HasDefaultValueSql("GETUTCDATE()");
            }

            // modelBuilder.Entity<ClientGroup>()
            // .HasMany(e => e.Clients)
            // .WithOne(e => e.ClientGroup)
            // .HasForeignKey(e => e.ClientGroupId)
            // .IsRequired();

            modelBuilder.Entity<ProductGroup>()
            .HasMany(e => e.Products)
            .WithOne(e => e.ProductGroup)
            .HasForeignKey(e => e.ProductGroupId)
            .IsRequired();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
