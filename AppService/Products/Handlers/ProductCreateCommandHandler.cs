using CleanArch.AppService.Products.Commands;
using CleanArch.Dominio.Entities;
using CleanArch.Dominio.Interfaces;
using MediatR;

namespace CleanArch.AppService.Products.Handlers
{
    internal class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(request.Name, request.Description, request.Price, 
                                request.Stock, request.Image);

            if(product is null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoryId = request.CategoryId;
                return await _productRepository.Create(product);
            }
        }
    }
}
