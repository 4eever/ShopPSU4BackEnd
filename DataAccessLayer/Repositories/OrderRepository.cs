using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddOrder(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _db.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _db.Orders.FindAsync(orderId);
        }

        public async Task UpdateOrder(Order order)
        {
            var existingOrder = await _db.Orders.FindAsync(order.OrderId);
            if (existingOrder != null)
            {
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.UserId = order.UserId;
                existingOrder.User = order.User;

                _db.Orders.Update(existingOrder);

                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await _db.Orders.FindAsync(orderId);
            if (order != null)
            {
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Order>> GetAllUserOrders(int userId)
        {
            return await _db.Orders.Where(o => o.UserId == userId).ToListAsync();
        }
    }
}
