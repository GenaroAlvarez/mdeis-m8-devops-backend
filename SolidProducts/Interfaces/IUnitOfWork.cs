using SolidProducts.Entities;

namespace SolidProducts.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Client> Clients { get; }
        IRepository<ClientGroup> ClientGroups { get; }
        IRepository<Invoice> Invoices { get; }
        IRepository<InvoiceDetail> InvoiceDetails { get; }
        IRepository<PaymentCondition> PaymentConditions { get; }
        IRepository<Product> Products { get; }
        IRepository<ProductGroup> ProductGroups { get; }
        IRepository<Warehouse> Warehouses { get; }
        
        Task<int> CommitAsync();
    }
}
