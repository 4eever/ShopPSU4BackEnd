using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        Task AddOrderItem(OrderItem orderItem);
        Task<List<OrderItem>> GetAllOrderItems();
        Task<OrderItem> GetOrderItemById(int orderItemId);
        Task UpdateOrderItem(OrderItem orderItem);
        Task DeleteOrderItem(int orderItemId);
        Task<List<OrderItem>> GetAllOrderItemsByOrderId(int orderId);
    }
}
