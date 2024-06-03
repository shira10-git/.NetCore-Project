using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using Repositories;
using System.Linq.Expressions;

namespace TestProjectMyShop
{
    public class CategoryRpositoryUnitTest
    {
        [Fact]
        public async Task TestGet_ReturnsCategories()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();

            mockDbContext.Setup(m => m.Categories).ReturnsDbSet(new List<Category> { new Category { CategoryId = 1, CategoryName = "Category1" } });
            var service = new CategoryRepository(mockDbContext.Object);

            // Act
            var result = await service.Get();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task TestGet_ReturnsCategories_UnHappy()
        {
            // Arrange
            var mockDbContext = new Mock<ShopDb325338135Context>();

            mockDbContext.Setup(m => m.Categories).ReturnsDbSet(new List<Category> { });
            var service = new CategoryRepository(mockDbContext.Object);

            // Act
            var result = await service.Get();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result, []);
        }
    }
}

