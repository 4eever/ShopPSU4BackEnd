using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services
{
    public interface IOrderService
    {
        Task<OrderDTO> AddOrder(OrderDTO orderDTO);
        Task<List<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(int orderId);
        Task<List<OrderDTO>> GetAllUserOrders(int userId);
    }
}
