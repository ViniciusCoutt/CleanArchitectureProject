using CleanArchProject.Application.DTOs;

namespace CleanArchProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductById(int? id);
        Task<IEnumerable<ProductDTO>> GetProductByCategoryId(int? id);
        Task Add(ProductDTO dto);
        Task Update(ProductDTO dto);
        Task Delete(int? id);

    }
}
