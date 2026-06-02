using CleanArchMvc.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetById(int? id);
        Task add(CategoryDTO categoryDTO);
        Task Update(CategoryDTO categoryDTO);
        Task Remove(int? id);
    }
}
