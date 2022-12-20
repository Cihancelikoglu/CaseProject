using CaseProject.Core.DataAccess;
using CaseProject.Entity.Entities;
using System.Linq.Expressions;

namespace CaseProject.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<bool> InsertCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);
    }
}
