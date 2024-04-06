using lab11.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11.CRUD.OrdersCRUD
{
    public interface IOrderRepository
    {
        Task<List<OrderViewModel>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<bool> DeleteOrderById(int id);
        Task<bool> AddNewOrder(Order model);
        Task<bool> UpdateOrder(Order model);

    }
}
