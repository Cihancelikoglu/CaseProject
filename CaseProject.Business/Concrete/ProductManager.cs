using CaseProject.Business.Abstract;
using CaseProject.Business.Constants;
using CaseProject.Core.Utilities.Result;
using CaseProject.Data.Abstract;
using CaseProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IDataResult<List<Product>>> GetAllAsync()
        {
            var response = await _productDal.FindAllAsync();
            return new SuccessDataResult<List<Product>>(response, Messages.ProductListed);
        }

        public async Task<IDataResult<Product>> GetByIdAsync(int id)
        {
            var response = await _productDal.FindByIdAsync(id);
            return new SuccessDataResult<Product>(response, Messages.ProductListed);
        }

        public async Task<IResult> AddAsync(Product product)
        {
            await _productDal.CreateAsync(product);
            return new Result(true, Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _productDal.DeleteAsync(id);
            return new Result(true, Messages.ProductDeleted);
        }

        public async Task<IResult> UpdateAsync(Product product)
        {
            await _productDal.UpdateAsync(product);
            return new Result(true, Messages.ProductUpdated);
        }
    }
}
