
using System.Collections.Generic;
using MyRestServices.BLL.DTOs;

namespace MyRestServices.BLL.Interfaces
{
    public interface IArticleBLL
    {
        Task<ArticleCreateDTO> Insert(ArticleCreateDTO article);
        Task<IEnumerable<ArticleDTO>> GetArticleWithCategory();
        Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId);
        Task<int> InsertWithIdentity(ArticleCreateDTO article);
        Task<ArticleUpdateDTO> Update(int id, ArticleUpdateDTO article);
        Task<bool> Delete(int id);
        Task <ArticleDTO> GetArticleById(int id);
        Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize);
        Task<int> GetCountArticles();
        Task <IEnumerable<ArticleDTO>> GetAll ();
        Task<ArticleDTO> GetById(int id);
    }
}
