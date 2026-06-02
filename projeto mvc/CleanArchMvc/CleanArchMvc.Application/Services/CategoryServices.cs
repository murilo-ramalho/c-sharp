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
    public class CategoryServices : ICategoryService
    {
        private ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryServices(ICategoryRepository categoryRpository, IMapper mapper)
        {
            _repository = categoryRpository;
            _mapper = mapper;
        }
        public async Task add(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _repository.CreateAsync(category);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categorieEntity = await _repository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categorieEntity);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _repository.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task Remove(int? id)
        {
            var category = _repository.GetCategoryByIdAsync(id).Result;
            await _repository.DeleteAsync(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _repository.UpdateAsync(category);
        }
    }
}
