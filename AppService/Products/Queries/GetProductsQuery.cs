using CleanArch.Dominio.Entities;
using MediatR;

namespace CleanArch.AppService.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
