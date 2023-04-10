using CleanArch.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Dominio.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProduct();
        Task<Product> GetById(int? id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Remove(Product product);
    }
}
