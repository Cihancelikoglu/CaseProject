using CaseProject.Core.DataAccess.Dapper;
using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Data.Abstract;
using CaseProject.Entity.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Data.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseSettings dbSettings)
            : base(dbSettings) { }

        public async Task<IEnumerable<Category>> GetCategoryAsync()
        {
            return await FindAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await FindByIdAsync(id);
        }

        public async Task<bool> InsertCategoryAsync(Category category)
        {
            return await CreateAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            return await UpdateAsync(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await DeleteAsync(id);
        }
    }
}
