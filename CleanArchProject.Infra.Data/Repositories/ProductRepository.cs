using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using CleanArchProject.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchProject.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product> CreateAsync(Product entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> DeleteAsync(Product entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryIdAsync(int? id)
        {
            IQueryable<Product> query = _context.Products;
            query = query.Where(p => p.CategoryId == id);
            return await query.ToListAsync();
        }
    }
}
