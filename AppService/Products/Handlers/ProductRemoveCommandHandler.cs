using CleanArch.AppService.Products.Commands;
using CleanArch.Dominio.Entities;
using CleanArch.Dominio.Interfaces;
using MediatR;

namespace CleanArch.AppService.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            
            if(product is null)
            {
                throw new ApplicationException($"Entity could not be found");
            }
            else
            {
                var result = await _productRepository.Remove(product);
                return result;
            }
        }
    }
}
