using AutoMapper;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;


namespace CleanArchProject.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _catRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _catRepository = categoryRepository ??
                throw new ArgumentNullException(nameof(categoryRepository)); ;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categories = await _catRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var category = await _catRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Add(CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _catRepository.CreateAsync(category);
        }
        public async Task Update(CategoryDTO dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _catRepository.UpdateAsync(category);
        }

        public async Task Delete(int? id)
        {
            var category = _catRepository.GetByIdAsync(id).Result;
            await _catRepository.DeleteAsync(category);
        }
    }
}
