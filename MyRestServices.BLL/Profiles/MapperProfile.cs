using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyRestServices.BLL.DTOs;
using MyRestServices.Domain.Models;

namespace MyRestServices.BLL.Profiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<CategoryCreateDTO, Category>();
            CreateMap<CategoryUpdateDTO, Category>();

            CreateMap<Article, ArticleDTO>().ReverseMap();
            CreateMap<ArticleCreateDTO, Article>();
            CreateMap<ArticleUpdateDTO, Article>();

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleCreateDTO, Role>();
        }
    }
}
