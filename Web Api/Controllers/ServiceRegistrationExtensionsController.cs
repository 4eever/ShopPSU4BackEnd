using BusinessAccessLayer.Mappings;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceRegistrationExtensionsController : ControllerBase
    {
        private readonly ICategotyRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public ServiceRegistrationExtensionsController(
            ICategotyRepository categoryRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository,
            IUserRepository userRepository,
            IOrderItemRepository orderItemRepository)
        {
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productRepository.GetAll();
            foreach (var product in products)
            {
                product.Category = _categoryRepository.GetById(product.CategoryId);
            }

            return Ok(products);
        }

        [HttpGet("orders/{userId}")]
        public IActionResult GetOrdersForUser(int userId)
        {
            var orders = _orderRepository.GetAll().Where(o => o.UserId == userId);
            foreach (var order in orders)
            {
                order.User = _userRepository.GetById(order.UserId);
                order.OrderItems = _orderItemRepository.GetAll().Where(oi => oi.OrderId == order.Id).ToList();
                foreach (var orderItem in order.OrderItems)
                {
                    orderItem.Product = _productRepository.GetById(orderItem.ProductId);
                }
            }
            return Ok(orders);
        }
    }
}
