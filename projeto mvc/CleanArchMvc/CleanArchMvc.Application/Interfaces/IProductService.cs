using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProductCategoryById(int id);
        Task<ProductDTO> GetById(int? id);
        Task add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int? id);
    }
}
