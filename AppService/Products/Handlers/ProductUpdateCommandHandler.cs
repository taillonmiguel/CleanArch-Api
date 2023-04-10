using CleanArch.AppService.Products.Commands;
using CleanArch.Dominio.Entities;
using CleanArch.Dominio.Interfaces;
using MediatR;

namespace CleanArch.AppService.Products.Handlers
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
            var product = await _productRepository.GetById(request.Id);
            
            if(product is null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, 
                        request.Stock, request.Image, request.CategoryId);

                return await _productRepository.Update(product);
            }
        }
    }
}
