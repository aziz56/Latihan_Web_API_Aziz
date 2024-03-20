using AutoMapper;
using MyRestServices.Data.Interface;
using MyRestServices.Domain.Models;
using MyRestServices.BLL.DTOs;
using System;
using System.Collections.Generic;
using MyRestServices.BLL.Interfaces;
namespace MyRestServices.BLL
{

    public class ArticleBLL : IArticleBLL
    {
       private readonly IArticleData _articleData;
        private readonly IMapper _mapper;

        public ArticleBLL(IArticleData articleData, IMapper mapper)
        {
            _articleData = articleData;
            _mapper = mapper;
        }
        public async Task<ArticleCreateDTO> Insert(ArticleCreateDTO article)
        {
            var articleToCreate = _mapper.Map<Article>(article);
            var articleCreated = await _articleData.Insert(articleToCreate);
            return _mapper.Map<ArticleCreateDTO>(articleCreated);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var article = await _articleData.GetById(id);
                if (article == null)
                {
                    throw new ArgumentException("Article not found");
                }
                await _articleData.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public async Task<IEnumerable<ArticleDTO>> GetAll()
        {
            var articles = await _articleData.GetAll();
            return _mapper.Map<IEnumerable<ArticleDTO>>(articles);
        }
        public async Task<ArticleDTO> GetById(int id)
        {
            var article = await _articleData.GetById(id);
            return _mapper.Map<ArticleDTO>(article);
        }
        public async Task<ArticleUpdateDTO> Update(int id, ArticleUpdateDTO article)
        {
            var articleToUpdate = await _articleData.GetById(id);
            if(articleToUpdate == null)
            {
                throw new ArgumentException("Article not found");
            }
            var articleUpdated = _mapper.Map(article, articleToUpdate);
            await _articleData.Update(id, articleUpdated);
            return _mapper.Map<ArticleUpdateDTO>(articleUpdated);

        }

        public Task<IEnumerable<ArticleDTO>> GetArticleWithCategory()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArticleDTO>> GetArticleByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertWithIdentity(ArticleCreateDTO article)
        {
            throw new NotImplementedException();
        }

        public Task<ArticleDTO> GetArticleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ArticleDTO>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            var getPaging = await _articleData.GetWithPaging(categoryId, pageNumber, pageSize);
            return _mapper.Map<IEnumerable<ArticleDTO>>(getPaging);
        }

        public async Task<int> GetCountArticles()
        {
            var count = await _articleData.GetCountArticles();
            return count;
            
        }
    }
}