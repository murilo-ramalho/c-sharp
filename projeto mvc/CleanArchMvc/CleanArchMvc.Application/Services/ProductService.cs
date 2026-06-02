using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _repository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var product = await _repository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(product);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var categorieEntity = await _repository.GetProductByIdAsync(id);
            return _mapper.Map<ProductDTO>(categorieEntity);
        }

        public async Task add(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _repository.CreateAsync(product);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _repository.UpdateAsync(product);
        }

        public async Task Remove(int? id)
        {
            var product = _repository.GetProductByIdAsync(id).Result;
            await _repository.DeleteAsync(product);
        }

        public async Task<ProductDTO> GetProductCategoryById(int id)
        {
            var product = await _repository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
