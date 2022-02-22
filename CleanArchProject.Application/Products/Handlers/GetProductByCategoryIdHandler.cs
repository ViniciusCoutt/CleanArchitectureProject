

using CleanArchProject.Application.Products.Queries;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Products.Handlers
{
    public class GetProductByCategoryIdHandler : IRequestHandler<GetProductByCategoryIdQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCategoryIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductByCategoryIdAsync(request.Id);
        }
    }
}
