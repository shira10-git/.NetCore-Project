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
        ShopDb325338135Context shopDbContext;
        private IOrderRepository orderRepository;
        private ILogger<OrderService> logger;

        public OrderService(IOrderRepository orderRepository, ShopDb325338135Context shopDbContext, ILogger<OrderService> logger)
        {
            this.orderRepository = orderRepository;
            this.shopDbContext = shopDbContext;
            this.logger = logger;
        }

        public async Task<Order> Post(Order order)
        {
            Product product;
            double sum = 0;
            foreach (var item in order.OrderItems)
            {
                product = await shopDbContext.Products.FirstOrDefaultAsync(p => p.ProductId == item.ProductId);
                sum = (double)(sum +product.Price*item.Quentity);
            }
            if (sum != order.OrderSum)
            {
                logger.LogError($"trying to steal {order.UserId}");
                return null;
            }

            Order newOrder=await orderRepository.Post(order);
            return newOrder;
        }
    }
}
