using CleanArchProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchProject.Application.Products.Queries
{
    public class GetProductByCategoryIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByCategoryIdQuery(int id)
        {
            Id = id;
        }
    }
}
