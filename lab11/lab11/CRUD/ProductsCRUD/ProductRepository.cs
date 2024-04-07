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

        public async Task<bool> AddNewProduct(Product model)
        {
            _context.Products.Add(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeleteProductById(int id)
        {
            Product model = await GetProductById(id);
            _context.Products.Remove(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
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

        public async Task<Product> GetProductById(int id)
        {
            Product model = await _context.Products.FindAsync(id);
            return model;
        }

        public async Task<bool> UpdateProduct(Product model)
        {
            var existingProduct = await _context.Products.FindAsync(model.ProductId);
            if (existingProduct != null)
            {
                _context.Entry(existingProduct).State = EntityState.Detached;//открепляем от контекста БД
            }

            _context.Products.Update(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

    }
}
