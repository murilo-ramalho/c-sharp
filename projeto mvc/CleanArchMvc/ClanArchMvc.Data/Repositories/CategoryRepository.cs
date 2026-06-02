using ClanArchMvc.Infra.Data.Context;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClanArchMvc.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext context) 
        {
            _categoryContext = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category> DeleteAsync(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id)
                ?? throw new InvalidOperationException("Category not found.");
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();
            return category;
        }
    }
}
