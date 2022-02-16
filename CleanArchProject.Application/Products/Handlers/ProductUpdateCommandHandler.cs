﻿using CleanArchProject.Application.Products.Commands;
using CleanArchProject.Domain.Entities;
using CleanArchProject.Domain.Interfaces;
using MediatR;

namespace CleanArchProject.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
                throw new ApplicationException($"Not found");

            product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image);
            return await _productRepository.UpdateAsync(product);
        }
    }
}
