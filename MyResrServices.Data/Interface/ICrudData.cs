using System.Collections.Generic;
using MyRestServices.Domain.Models;

namespace MyRestServices.Data.Interface
{

    public interface ICrudData<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T entity);
        Task<T> Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
