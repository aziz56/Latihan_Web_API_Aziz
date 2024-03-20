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
    public class CategoryData : ICategoryData
    {
        private readonly AppDbContext _context;
        public CategoryData(AppDbContext context)
        {   _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            _context.Categories.Remove(category);
            if (category == null)
            await _context.SaveChangesAsync();
            return true;
            
         
           
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var getAll = await _context.Categories.ToListAsync();
            return getAll;
        }

        public async Task<Category> GetById(int id)
        {
            try
            {
                var getById = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
                return getById;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public Task<IEnumerable<Category>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
            //try
            //{
                
            //    int itemsToSkip = (pageNumber - 1) * pageSize;

            //    // Query dasar untuk mengambil data dari database
            //    var query = await _context.Categories.AsQueryable();

                
            //    if (!string.IsNullOrEmpty(name))
            //    {
            //        query = query.Where(c => c.Name.Contains(name));
            //    }

            //    // Lakukan skip dan take untuk melakukan paging
            //    var categories = query
            //        .OrderBy(c => c.Name)  // Atur urutan jika diperlukan
            //        .Skip(itemsToSkip)     // Lewati sejumlah item berdasarkan nomor halaman
            //        .Take(pageSize)        // Ambil sejumlah item sesuai ukuran halaman
            //        .ToListAsync();        // Eksekusi query dan konversi hasilnya menjadi List async

            //    return categories;
            //}
            //catch (Exception ex)
            //{
            //    // Tangani exception di sini jika diperlukan
            //    throw;
            //}
        }


        public async Task<Category> Insert(Category entity)
        {
            try
            {
                await _context.Categories.AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        //public async Task<Task> Insert(Category entity)
        //{
        //    try
        //    {
        //        await _context.Categories.AddAsync(entity);
        //        await _context.SaveChangesAsync();
        //        return entity;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }


        //}


        public Task<int> InsertWithIdentity(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertWithIdentity(int id, Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(int id, Category entity)
        {
            try
            {
                _context.Categories.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }

}
