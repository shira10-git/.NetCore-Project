using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class ProductRepositoryIntegrationTest: IClassFixture<DatabaseFixture>
    {
        private readonly ShopDb325338135Context _dbContext;
        private readonly ProductRepository _productRepository;

        public ProductRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _productRepository = new ProductRepository(_dbContext);
        }
        [Fact]
        public async Task GetCategory_returnsCategories()
        {
            var category = new Category { CategoryName = "מתח" };
            var product = new Product { CategoryId=1,Description="aaa",Image="aaa/jpg" };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            //act
            var result = await _productRepository.Get("a", 10, 50, [1],1,20);

            //assert

            Assert.NotNull(result);
        }
    }
}
