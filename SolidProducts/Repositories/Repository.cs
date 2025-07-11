using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolidProducts.Data;
using SolidProducts.Entities;
using SolidProducts.Interfaces;

namespace SolidProducts.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        public Repository(AppDbContext context) => _context = context;

        public async Task<T> AddAsync(T entity)
        {
            var entry = await _context.Set<T>().AddAsync(entity);
            return entry.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public IQueryable<T> Query()
        {
            return _context.Set<T>().AsNoTracking();
        }
    }
}
