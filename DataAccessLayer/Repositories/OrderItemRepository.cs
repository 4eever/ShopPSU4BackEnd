using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public readonly ApplicationContext _db;

        public OrderItemRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddOrderItem(OrderItem orderItem)
        {
            await _db.OrderItems.AddAsync(orderItem);
            await _db.SaveChangesAsync();
        }

        public async Task<List<OrderItem>> GetAllOrderItems()
        {
            return await _db.OrderItems.ToListAsync();
        }

        public async Task<OrderItem> GetOrderItemById(int orderItemId)
        {
            return await _db.OrderItems.FindAsync(orderItemId);
        }

        public async Task UpdateOrderItem(OrderItem orderItem)
        {
            var existingOrderItem = await _db.OrderItems.FindAsync(orderItem.OrderItemId);
            if (existingOrderItem != null)
            {
                existingOrderItem.OrderId = orderItem.OrderId;
                existingOrderItem.ProductId = orderItem.ProductId;
                existingOrderItem.ProductQuantity = orderItem.ProductQuantity;
                existingOrderItem.Product = orderItem.Product;
                existingOrderItem.Order = orderItem.Order;

                _db.OrderItems.Update(existingOrderItem);

                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderItem(int orderItemId)
        {
            var orderItem = await _db.OrderItems.FindAsync(orderItemId);
            if (orderItem != null)
            {
                _db.OrderItems.Remove(orderItem);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<OrderItem>> GetAllOrderItemsByOrderId(int orderId)
        {
            return await _db.OrderItems.Where(oi => oi.OrderId == orderId).ToListAsync();
        }
    }
}
