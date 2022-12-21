using CaseProject.Core.Utilities.Result;
using CaseProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<Product>>> GetAllAsync();
        Task<IDataResult<Product>> GetByIdAsync(int id);
        Task<IResult> AddAsync(Product product);
        Task<IResult> UpdateAsync(Product product);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> IsStatus(int id);
    }
}