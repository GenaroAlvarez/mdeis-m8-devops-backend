using SolidProducts.Data;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Product> Products { get; }
        public IRepository<ProductGroup> ProductGroups { get; }
        public IRepository<Manufacturer> Manufacturers { get; }
        public IRepository<Supplier> Suppliers { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new Repository<Product>(context);
            ProductGroups = new Repository<ProductGroup>(context);
            Manufacturers = new Repository<Manufacturer>(context);
            Suppliers = new Repository<Supplier>(context);
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
