using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface ICategotyRepository
    {
        Task AddCategory(Category category);
        Task<Category> GetCategoryById(int categoryId);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<List<Category>> GetAllCategories();
    }
}
