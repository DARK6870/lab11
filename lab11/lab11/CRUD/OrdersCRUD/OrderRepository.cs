using lab11.CRUD.OrdersCRUD;
using lab11.DataBase;
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
                ProductName = order.Products.Name,
                UserName = order.Users.UserName,
                Quantity = order.Quantity,
                TotalPrice = order.TotalPrice,
                StatusName = order.Statuses.StatusName
            }).ToList();

            return orderViewModels;
        }
    }
}
