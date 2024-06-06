using DTO;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectMyShop
{
    public class CategoryRepositoryIntegrationTest: IClassFixture<DatabaseFixture>
    {
        private readonly ShopDb325338135Context _dbContext;
        private readonly CategoryRepository _categoryRepository;

        public CategoryRepositoryIntegrationTest(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _categoryRepository = new CategoryRepository(_dbContext);
        }
        [Fact]
        public async Task GetCategory_returnsCategories()
        {
            var category = new Category { CategoryName = "מתח" };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            //act
            var result = await _categoryRepository.Get();

            //assert

            Assert.NotNull(result);
        }
    }
}
