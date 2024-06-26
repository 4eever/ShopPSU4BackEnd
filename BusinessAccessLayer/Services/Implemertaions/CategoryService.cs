using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessAccessLayer.Services.Implemertaions
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategotyRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategotyRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<CategoryDTO, Category>(categoryDTO);
            await _categoryRepository.AddCategory(categoryEntity);

            var category = await _categoryRepository.GetCategoryByName(categoryEntity.CategoryName);
            var categoryDTOResult = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTOResult;
        }

        public async Task<List<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();

            var categoriesDTO = (from c in categories
                                 select _mapper.Map<Category, CategoryDTO>(c)
                                ).ToList();

            return categoriesDTO;
        }

        public async Task<CategoryDTO> GetCategoryById(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var categoryDTO = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTO;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);

            if (category == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _categoryRepository.DeleteCategory(categoryId);
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<CategoryDTO, Category>(categoryDTO);

            var categoryCheck = _categoryRepository.GetCategoryById(categoryEntity.CategoryId);

            if (categoryCheck == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _categoryRepository.UpdateCategory(categoryEntity);

            var category = await _categoryRepository.GetCategoryByName(categoryEntity.CategoryName);
            var categoryDTOResult = _mapper.Map<Category, CategoryDTO>(category);

            return categoryDTOResult;
        }


    }
}
