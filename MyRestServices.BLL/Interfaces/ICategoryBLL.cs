
using MyRestServices.BLL.DTOs;

namespace MyRestServices.BLL.Interfaces
{
    public interface ICategoryBLL
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CategoryDTO>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<IEnumerable<CategoryDTO>> GetByName(string name);
        Task<CategoryCreateDTO> Insert(CategoryCreateDTO entity);
        Task<CategoryUpdateDTO> Update(int id, CategoryUpdateDTO entity);
        Task<IEnumerable<CategoryDTO>> GetWithPaging(int pageNumber, int pageSize, string name);
        Task<int> GetCountCategories(string name);


    }
}
