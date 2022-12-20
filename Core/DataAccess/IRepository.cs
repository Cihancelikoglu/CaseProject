using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Core.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);

        //Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
