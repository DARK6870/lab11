using lab11.CRUD.OrdersCRUD;
using lab11.DataBase;
using lab11.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab11.CRUD.OrdersCRUD
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDBContext _context;
        public OrderRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewOrder(Order model)
        {
            _context.Orders.Add(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<bool> DeleteOrderById(int id)
        {
            Order order = await GetOrderById(id);
            _context.Orders.Remove(order);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }

        public async Task<List<OrderViewModel>> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.Products)
                .Include(o => o.Users)
                .Include(o => o.Statuses)
                .ToListAsync();

            var orderViewModels = orders.Select((order, index) => new OrderViewModel
            {
                i = index + 1,
                OrderId = order.OrderId,
                ProductName = order.Products.ProductName,
                UserName = order.Users.UserName,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                StatusName = order.Statuses.StatusName
            }).ToList();

            return orderViewModels;
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order model = await _context.Orders.FindAsync(id);
            return model;
        }

        public async Task<bool> UpdateOrder(Order model)
        {
            _context.Orders.Update(model);
            int res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }
}
