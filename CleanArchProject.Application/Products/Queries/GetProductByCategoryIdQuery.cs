using CleanArchProject.Domain.Entities;
using MediatR;

namespace CleanArchProject.Application.Products.Queries
{
    public class GetProductByCategoryIdQuery : IRequest<IEnumerable<Product>>
    {
        public int Id { get; set; }
        public GetProductByCategoryIdQuery(int id)
        {
            Id = id;
        }
    }
}
