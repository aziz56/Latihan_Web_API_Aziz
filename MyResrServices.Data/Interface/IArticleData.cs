﻿
using MyRestServices.Domain.Models;

namespace MyRestServices.Data.Interface
{
    public interface IArticleData : ICrudData<Article>
    {
        Task<IEnumerable<Article>> GetArticleWithCategory();
        Task<IEnumerable<Article>> GetArticleByCategory(int categoryId);
        Task<IEnumerable<Article>> GetWithPaging(int categoryId, int pageNumber, int pageSize);

        Task<int> GetCountArticles();
        Task<int> InsertWithIdentity(Article article);

        Task<Task> InsertArticleWithCategory(Article article);
    }
}
