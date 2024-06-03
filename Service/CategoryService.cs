using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }


        public async Task<List<Category>> Get()
        {
            var category = await categoryRepository.Get();
            return category;
        }

        public async Task<List<Category>> Get(int id)
        {
            var category = await categoryRepository.Get(id);
            return category;
        }
    }
}
