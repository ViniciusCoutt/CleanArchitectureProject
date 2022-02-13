using CleanArchProject.Domain.Entities;

namespace CleanArchProject.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        
        Task<IEnumerable<Product>> GetProductByCategoryIdAsync(int? id);
    }
}
