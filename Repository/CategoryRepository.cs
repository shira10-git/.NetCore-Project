using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        ShopDb325338135Context shopDbContext;
        public CategoryRepository(ShopDb325338135Context shopDbContext)
        {
            this.shopDbContext = shopDbContext;
        }
        public async Task<List<Category>> Get()
        {
            var category = await shopDbContext.Categories.ToListAsync();                                     
            return category;
        }

        public async Task<List<Category>> Get(int id)
        {
            var category = await shopDbContext.Categories.Where(c=>c.CategoryId==id).ToListAsync();
            return category;
        }

    }
}
