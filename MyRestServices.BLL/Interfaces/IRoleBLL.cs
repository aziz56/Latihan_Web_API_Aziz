﻿
using MyRestServices.BLL.DTOs;

namespace MyRestServices.BLL.Interfaces
{
    public interface IRoleBLL
    {
        IEnumerable<RoleDTO> GetAllRoles();
        void AddRole(string roleName);
        void AddUserToRole(string username, int roleId);
    }
}
