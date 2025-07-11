using SolidProducts.Entities;

namespace SolidProducts.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Product> Products { get; }
        IRepository<ProductGroup> ProductGroups { get; }
        IRepository<Manufacturer> Manufacturers { get; }
        IRepository<Supplier> Suppliers { get; }
        Task<int> CommitAsync();
    }
}
