using lab11.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.ProductsCRUD
{
    public interface IProductRepository
    {
        Task<List<ProductViewModel>> GetAllProducts();
        Task<bool> AddNewProduct(Product model);
        Task<bool> DeleteProductById(int id);
        Task<bool> UpdateProduct(Product model);
        Task<Product> GetProductById(int id);
    }
}
