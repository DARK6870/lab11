using lab11.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.CategoryCRUD
{
    public interface ICategoryRepository
    {
        Task<List<CategoryViewModel>> GetAllCategories();
        Task<Category> GetCategoryById(byte id);
        Task<bool> DeleteCategoryById(byte id);
        Task<bool> AddNewCategory(Category model);
        Task<bool> UpdateCategory(Category model);
    }
}
