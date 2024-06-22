using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO);
        Task<CategoryDTO> GetCategoryById(int categoryId);
        Task<CategoryDTO> UpdateCategory(CategoryDTO category);
        Task DeleteCategory(int categoryId);
        Task<List<CategoryDTO>> GetAllCategories();
    }
}
