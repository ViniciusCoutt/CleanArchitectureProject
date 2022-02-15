using AutoMapper;
using CleanArchProject.Application.DTOs;
using CleanArchProject.Application.Interfaces;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;

namespace CleanArchProject.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _prodRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _prodRepository = productRepository ?? 
                throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = await _prodRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var product = await _prodRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductByCategoryId(int? id)
        {
            var product = await _prodRepository.GetProductByCategoryIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _prodRepository.CreateAsync(product);
        }

        public async Task Delete(int? id)
        {
            var product = _prodRepository.GetByIdAsync(id).Result;
            await _prodRepository.DeleteAsync(product);
        }

        public async Task Update(ProductDTO dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _prodRepository.UpdateAsync(product);
        }
    }
}
