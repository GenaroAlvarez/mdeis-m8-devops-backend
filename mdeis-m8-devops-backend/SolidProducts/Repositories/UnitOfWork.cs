using SolidProducts.Data;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IRepository<Warehouse> Warehouses { get; }
        public IRepository<ClientGroup> ClientGroups { get; }
        public IRepository<ProductGroup> ProductGroups { get; }
        public IRepository<PaymentCondition> PaymentConditions { get; }
        public IRepository<Product> Products { get; }
        public IRepository<Client> Clients { get; }
        public IRepository<Invoice> Invoices { get; }
        public IRepository<InvoiceDetail> InvoiceDetails { get; }
        public IRepository<DocumentType> DocumentTypes { get; }


        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            PaymentConditions = new Repository<PaymentCondition>(context);
            Warehouses = new Repository<Warehouse>(context);
            ProductGroups = new Repository<ProductGroup>(context);
            ClientGroups = new Repository<ClientGroup>(context);
            Clients = new Repository<Client>(context);
            Products = new Repository<Product>(context);
            Invoices = new Repository<Invoice>(context);
            InvoiceDetails = new Repository<InvoiceDetail>(context);
            DocumentTypes = new Repository<DocumentType>(context);
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
