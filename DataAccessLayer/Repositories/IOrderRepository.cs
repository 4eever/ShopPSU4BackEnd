using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrder(Order order);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int orderId);
        Task UpdateOrder(Order order);
        Task DeleteOrder(int orderId);
        Task<List<Order>> GetAllUserOrders(int userId);
    }
}
