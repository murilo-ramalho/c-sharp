using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductAsync();
        Task<Product> GetProductByIdAsync(int? id);

        Task<Product> GetProductCategoryAsync(int? id);

        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> DeleteAsync(Product product);
    }
}
