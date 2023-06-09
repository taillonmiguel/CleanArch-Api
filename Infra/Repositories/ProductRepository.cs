﻿using CleanArch.Dominio.Entities;
using CleanArch.Dominio.Interfaces;
using CleanArch.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> Create(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(int? id)
        {
            return await _productContext.Products
                .Include(x=> x.Category)
                .FirstAsync(x=> x.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProduct()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> GetProductCategory(int? id)
        {
            //eager loading
            return await _productContext.Products
                .Include(x => x.Category)
                .FirstAsync(x => x.Id == id);
        }

        public async Task<Product> Remove(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
