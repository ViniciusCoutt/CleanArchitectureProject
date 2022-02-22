using CleanArchProject.Application.Products.Commands;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
        }
        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null) throw new ApplicationException($"Entity could not be found.");

            return await _productRepository.DeleteAsync(product);
        }
    } 
}
