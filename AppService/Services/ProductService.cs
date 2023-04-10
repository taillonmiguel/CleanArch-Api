﻿using AutoMapper;
using CleanArch.AppService.DTOs;
using CleanArch.AppService.Interfaces;
using CleanArch.AppService.Products.Commands;
using CleanArch.AppService.Products.Queries;
using MediatR;

namespace CleanArch.AppService.Services
{
    public class ProductService : IProductService
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsQuery = new GetProductsQuery();

            if(productsQuery is null)
            {
                throw new Exception("Entity could not be loaded.");
            }

            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productByIdQuery = new GetProductByIdQuery(id.Value);

            if(productByIdQuery is null)
            {
                throw new Exception("Entity could not be loaded.");
            }
            
            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task Add(ProductDTO productDTO)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var productRemoveCommand = new ProductRemoveCommand(id.Value);

            if(productRemoveCommand is null)
            {
                throw new Exception("Entity could not be loaded.");
            }

            await _mediator.Send(productRemoveCommand);
        }
    }
}
