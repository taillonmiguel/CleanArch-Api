using CleanArch.Dominio.Entities;
using MediatR;

namespace CleanArch.AppService.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
