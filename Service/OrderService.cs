using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        ShopDb325338135Context _shopDbContext;
        private IOrderRepository _orderRepository;
        private ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ShopDb325338135Context shopDbContext, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _shopDbContext = shopDbContext;
            _logger = logger;
        }

        public async Task<Order> Post(Order order)
        {
            double sum = await checkThief(order);
            if (sum != order.OrderSum)
            {
                _logger.LogError($"trying to steal {order.UserId}");
                return null;
            }

            Order newOrder = await _orderRepository.Post(order);
            return newOrder;
        }

        private async Task<double> checkThief(Order order)
        {
            double sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product product;
                product = await _shopDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == item.ProductId);
                if (product == null)
                    return 0;
                sum = (double)(sum + product.Price * item.Quentity);
            }
            return sum;
        }

    }
}
