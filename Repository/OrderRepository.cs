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

        ShopDb325338135Context _shopDbContext;
        public OrderRepository(ShopDb325338135Context shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<Order> Post(Order order)
        {
           await _shopDbContext.Orders.AddAsync(order);
           await _shopDbContext.SaveChangesAsync();
           return order;
        }
    }
}
