using CleanArch.Dominio.Entities;
using MediatR;

namespace CleanArch.AppService.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
