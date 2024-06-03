using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class OrderRepositoryUnitTest
    {
        [Fact]
        public async Task Post_AddsOrderToDatabaseAndReturnsSameOrder()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();

            OrderItem oi = new OrderItem { Quentity = 1, ProductId = 4 };
            var order = new Order { OrderId = 1, OrderDate = new DateTime(), OrderSum = 200, UserId = 12 };
            var orderPost = new Order { OrderId = 2, OrderDate = new DateTime(), OrderSum = 200, UserId = 12, OrderItems = [oi] };
            mockDbContext.Setup(m => m.Orders).ReturnsDbSet(new List<Order> { order });
            var service = new OrderRepository(mockDbContext.Object);

            // Act
            var result = await service.Post(orderPost);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(orderPost.OrderSum, result.OrderSum);
        }

        //[Fact]
        //public async Task Post_AddsOrderToDatabaseAndReturnsSameOrder_UnHappy()
        //{
        //    // Arrange
        //    var mockDbContext = new Mock<ShopDb325338135Context>();

        //    OrderItem oi = new OrderItem { Quentity = 1, ProductId = 4 };
        //    var order = new Order { OrderId = 1, OrderDate = new DateTime(), OrderSum = 200, UserId = 12 };
        //    var orderPost = new Order { OrderId = 2, OrderDate = new DateTime(), OrderSum = 0, UserId = 12, OrderItems = [oi] };
        //    mockDbContext.Setup(m => m.Orders).ReturnsDbSet(new List<Order> { order });
        //    var service = new OrderRepository(mockDbContext.Object);

        //    // Act
        //    var result = await service.Post(orderPost);

        //    // Assert
        //    Assert.Null(result);
        //}
    }
}
