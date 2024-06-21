using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CategotyRepository : ICategotyRepository
    {
        public readonly ApplicationContext _db;

        public CategotyRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddCategory(Category category)
        {
            await _db.Categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _db.Categories.FindAsync(categoryId);
        }

        public async Task UpdateCategory(Category category)
        {
            var existingCategory = await _db.Categories.FindAsync(category.CategoryId);
            if (existingCategory != null)
            {
                existingCategory.CategoryName = category.CategoryName;

                _db.Categories.Update(existingCategory);

                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _db.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _db.Categories.Remove(category);
                await _db.SaveChangesAsync();
            }
        }
    }
}
