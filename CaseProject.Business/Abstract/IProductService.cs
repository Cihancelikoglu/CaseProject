using CaseProject.Core.Utilities.Result;
using CaseProject.Entity.Entities;
using Microsoft.AspNetCore.Http;
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
        Task<IResult> AddAsync(IFormFile file, Product product);
        Task<IResult> UpdateAsync(IFormFile file, Product product);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> IsStatus(int id);
    }
}