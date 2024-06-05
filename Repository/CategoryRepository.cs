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
        ShopDb325338135Context _shopDbContext;
        public CategoryRepository(ShopDb325338135Context shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }
        public async Task<List<Category>> Get()
        {
            var category = await _shopDbContext.Categories.ToListAsync();                                     
            return category;
        }

        public async Task<List<Category>> Get(int id)
        {
            var category = await _shopDbContext.Categories.Where(c=>c.CategoryId==id).ToListAsync();
            return category;
        }

    }
}
