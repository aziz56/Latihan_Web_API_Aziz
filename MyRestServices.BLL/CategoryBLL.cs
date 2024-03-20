using AutoMapper;
using MyRestServices.Data.Interface;
using MyRestServices.Domain.Models;
using MyRestServices.BLL.DTOs;
using System;
using System.Collections.Generic;
using MyRestServices.BLL.Interfaces;

namespace MyRestServices.BLL
{
    public class CategoryBLL : ICategoryBLL
    {
        private readonly ICategoryData _categoryData;
        private readonly IMapper _mapper;

        public CategoryBLL(ICategoryData categoryData, IMapper mapper)
        {
            _categoryData = categoryData;
            _mapper = mapper;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var category = await _categoryData.GetById(id);
                if (category == null)
                {
                    throw new ArgumentException("Category not found");
                }
                await _categoryData.Delete(id);
                return true;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
         var categories = await _categoryData.GetAll();
         return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
           
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var category = await _categoryData.GetById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public Task<IEnumerable<CategoryDTO>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryCreateDTO> Insert(CategoryCreateDTO entity)
        {
            var category = await _categoryData.Insert(_mapper.Map<Category>(entity));
            return _mapper.Map<CategoryCreateDTO>(category);

        }

        public async Task<CategoryUpdateDTO> Update(int id, CategoryUpdateDTO entity)
        {
            try
            {
                var category = await _categoryData.GetById(id);
                if (category == null)
                {
                    throw new ArgumentException("Category not found");
                }
                var updateCategory = _mapper.Map<Category>(entity);
                await _categoryData.Update(id, updateCategory);
                return entity;
            
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            

        }
    }
}
