using lab11.CRUD.OrdersCRUD;
using lab11.DataBase;
using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    }
}
