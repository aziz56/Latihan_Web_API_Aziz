using System.Collections.Generic;
using MyRestServices.Domain.Models;
using MyRestServices.Data.Interface;

namespace MyRestServices.Data.Interface
{

    public interface ICategoryData : ICrudData<Category>
    {
        Task<IEnumerable<Category>> GetByName(string name);
        Task<IEnumerable<Category>> GetWithPaging(int categoryId, int pageSize, string name);
        Task<int> GetCountCategories(string name);
        Task<int> InsertWithIdentity(int id, Category category);
    }
}
