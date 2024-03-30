using lab11.DataBase;
using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.ProductsCRUD
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;

        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Categories)
                .ToListAsync();

            var numberedProducts = products.Select((product, index) => new
            {
                i = index + 1,
                Product = product
            });

            var result = numberedProducts.Select(item => new ProductViewModel
            {
                i = item.i,
                ProductId = item.Product.ProductId,
                Name = item.Product.Name,
                Price = item.Product.Price,
                CategoryName = item.Product.Categories.CategoryName,
                Available = item.Product.Available
            }).ToList();

            return result;
        }

    }
}
