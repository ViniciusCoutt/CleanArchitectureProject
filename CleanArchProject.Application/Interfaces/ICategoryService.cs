using CleanArchProject.Application.DTOs;

namespace CleanArchProject.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryById(int? id);
        Task Add(CategoryDTO dto);
        Task Update(CategoryDTO dto);
        Task Delete(int? id);
    }
}
