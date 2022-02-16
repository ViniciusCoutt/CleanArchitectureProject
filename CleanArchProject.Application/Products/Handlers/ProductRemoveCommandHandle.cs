using CleanArchProject.Application.Products.Commands;
using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Products.Handlers
{
    public class ProductRemoveCommandHandle : IRequestHandler<ProductRemoveCommand, Product>
    {
        public Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}
