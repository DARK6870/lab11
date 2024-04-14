using lab11.CRUD.OrdersCRUD;
using lab11.DataBase;
using lab11.Entityes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.CategoryCRUD
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewCategory(Category model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.Categories.AddAsync(model);
                    int res = await _context.SaveChangesAsync();
                    if (res > 0)
                    {
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }


        public async Task<bool> DeleteCategoryById(byte id)
        {
            var model = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            var categoryViewModels = categories.Select((category, index) => new CategoryViewModel
            {
                i = index + 1,
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            }).ToList();

            return categoryViewModels;
        }

        public async Task<List<string>> GetAllCategoryNames()
        {
            var categoies = await _context.Categories.ToListAsync();
            List<string> res = categoies.Select(p => p.CategoryName).ToList();
            return res;
        }

        public async Task<Category> GetCategoryById(byte id)
        {
            var res = await _context.Categories.FindAsync(id);
            return res;
        }

        public async Task<byte> GetCategoryIdByCategoryName(string name)
        {
            Category model = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryName == name);
            byte res = model.CategoryId;
            return res;
        }

        public async Task<byte> GetCategoryIdByCategoryNameProcedure(string name)
        {
            var result = _context.Categories
                .FromSqlRaw("EXEC GetCategoryByCategoryNameProcedure @CategoryName", new SqlParameter("@CategoryName", name)).AsEnumerable();

            if (result != null)
            {
                return result.FirstOrDefault().CategoryId;
            }
            else
            {
                return 0;
            }
        }


        public async Task<bool> UpdateCategory(Category model)
        {
            _context.Categories.Update(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

    }
}
