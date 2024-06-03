using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {

        ShopDb325338135Context shopDbContext;
        public OrderRepository(ShopDb325338135Context shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }
        public async Task<Order> Post(Order order)
        {
           await shopDbContext.Orders.AddAsync(order);
           await shopDbContext.SaveChangesAsync();
           return order;
        }
    }
}
