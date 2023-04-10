using CleanArch.AppService.Products.Queries;
using CleanArch.Dominio.Entities;
using CleanArch.Dominio.Interfaces;
using MediatR;

namespace CleanArch.AppService.Products.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(request.Id);
        }
    }
}
