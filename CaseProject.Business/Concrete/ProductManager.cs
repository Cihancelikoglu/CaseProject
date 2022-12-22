using CaseProject.Business.Abstract;
using CaseProject.Business.Constants;
using CaseProject.Core.Utilities.Helpers.FileHelper.Abstract;
using CaseProject.Core.Utilities.Helpers.FileHelper.Concrete;
using CaseProject.Core.Utilities.Result;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;
using CaseProject.Entity.Entities;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;
        public ProductManager(IProductDal productDal, IFileHelper fileHelper)
        {
            _productDal = productDal;
            _fileHelper = fileHelper;
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

        public async Task<IResult> AddAsync(IFormFile file, Product product)
        {
            product.Image = await _fileHelper.Upload(file, PathConstants.pathSeparator);
            await _productDal.CreateAsync(product);
            return new Result(true, Messages.ProductAdded);
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _productDal.DeleteAsync(id);
            return new Result(true, Messages.ProductDeleted);
        }

        public async Task<IResult> UpdateAsync(IFormFile file, Product product)
        {
            if (file != null)
            {
                product.Image = await _fileHelper.Update(file, PathConstants.pathSeparator + product.Image, PathConstants.pathSeparator);
            }
            await _productDal.UpdateAsync(product);
            return new Result(true, Messages.ProductUpdated);
        }

        public async Task<IResult> IsStatus(int id)
        {
            var response = await _productDal.FindByIdAsync(id);
            if (response.Status == true)
            {
                response.Status = false;
            }
            else
            {
                response.Status = true;
            }
            await _productDal.UpdateAsync(response);
            return new Result(true, "Başarılı");
        }
    }
}
