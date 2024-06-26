using AutoMapper;
using BusinessAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using BusinessAccessLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessAccessLayer.Services.Implemertaions
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDTO> AddOrder(OrderDTO orderDTO)
        {
            var orderEntity = _mapper.Map<OrderDTO, Order>(orderDTO);
            await _orderRepository.AddOrder(orderEntity);

            var order = await _orderRepository.GetOrderByDateAndUserId(orderEntity.OrderDate, orderEntity.UserId);
            var orderDTOResult = _mapper.Map<Order, OrderDTO>(order);

            return orderDTOResult;
        }

        public async Task<List<OrderDTO>> GetAllOrders()
        {
            var orders = await _orderRepository.GetAllOrders();

            var ordersDTO = (from o in orders
                             select _mapper.Map<Order, OrderDTO>(o)
                             ).ToList();

            return ordersDTO;
        }

        public async Task<OrderDTO> GetOrderById(int orderId)
        {
            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var orderDTO = _mapper.Map<Order, OrderDTO>(order);

            return orderDTO;
        }

        public async Task<List<OrderDTO>> GetAllUserOrders(int userId)
        {
            var orders = await _orderRepository.GetAllUserOrders(userId);

            var ordersDTO = (from o in orders
                             select _mapper.Map<Order, OrderDTO>(o)
                             ).ToList();

            return ordersDTO;
        }
    }
}