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
    }
}
