using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace SolidProducts.Data
{
    public class DesignTimeDbContextFactory
        : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            // Conexión a tu contenedor SQL Server
            builder.UseSqlServer(
              "Server=localhost;Database=products;Trusted_Connection=True;Encrypt=False;"
            );
            return new AppDbContext(builder.Options);
        }
    }
}
