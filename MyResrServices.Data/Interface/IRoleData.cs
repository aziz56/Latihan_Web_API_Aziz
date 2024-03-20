using MyRestServices.Domain.Models;

namespace MyRestServices.Data.Interface
{

    public interface IRoleData : ICrudData<Role>
    {
        Task<Task> AddUserToRole(string username, int roleId);
    }
}
