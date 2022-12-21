using CaseProject.Core.Utilities.Result;
using CaseProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAllAsync();
        Task<IDataResult<Category>> GetByIdAsync(int id);
        Task<IResult> AddAsync(Category category);
        Task<IResult> UpdateAsync(Category category);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> IsStatus(int id);
    }
}