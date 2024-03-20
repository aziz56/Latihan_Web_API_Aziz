using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyRestServices.Data.Interface;
using MyRestServices.Domain.Models;


namespace MyRestServices.Data
{
    public class ArticleData:IArticleData
    {
        private readonly AppDbContext _context;
        public ArticleData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(x => x.ArticleId == id);
            _context.Articles.Remove(article);
            if (article == null)
                await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Article>> GetAll()
        {
            var getAll = await _context.Articles.ToListAsync();
            return getAll;
        }

        public Task<IEnumerable<Article>> GetArticleByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetArticleWithCategory()
        {
            throw new NotImplementedException();
        }

        public async Task<Article> GetById(int id)
        {
            try
            {
                var getById = await _context.Articles.FirstOrDefaultAsync(x => x.ArticleId == id);
                return getById;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> GetCountArticles(string name)
        {
            var getCount = await _context.Articles.Where(x => x.Title.Contains(name)).CountAsync();
            return getCount;
        }

        public Task<int> GetCountArticles()
        {
            var getCount = _context.Articles.CountAsync();
            return getCount;
        }

        public async Task<IEnumerable<Article>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            var getWithPaging = await _context.Articles.Where(x => x.CategoryId == categoryId)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return getWithPaging;
        }


        public async Task<Article> Insert(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return article;
        }

        public Task<Task> InsertArticleWithCategory(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertWithIdentity(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task<Article> Update(int id, Article entity)
        {
            try
            {
              var update = await _context.Articles.FirstOrDefaultAsync(x => x.ArticleId == id);
                if (update == null)
                {
                    throw new ArgumentException("Article not found");
                }
                update.Title = entity.Title;
                update.CategoryId = entity.CategoryId;
                await _context.SaveChangesAsync();
            }
            catch
           {
                throw new ArgumentException("Article not found");
            }
            return entity;
        }
    }
}
