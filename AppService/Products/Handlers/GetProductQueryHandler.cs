using CleanArch.AppService.Products.Queries;
using CleanArch.Dominio.Entities;
using CleanArch.Dominio.Interfaces;
using MediatR;

namespace CleanArch.AppService.Products.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProduct();
        }
    }
}
