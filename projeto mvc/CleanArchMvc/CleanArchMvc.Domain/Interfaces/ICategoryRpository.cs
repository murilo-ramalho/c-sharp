using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchMvc.Domain.Interfaces
{
    public interface ICategoryRpository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int? id);

        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(Category category);
    }
}
