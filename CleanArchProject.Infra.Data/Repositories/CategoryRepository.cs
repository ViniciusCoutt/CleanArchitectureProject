using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using CleanArchProject.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchProject.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> CreateAsync(Category entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Category> DeleteAsync(Category entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Category> UpdateAsync(Category entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
