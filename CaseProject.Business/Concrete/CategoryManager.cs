using CaseProject.Business.Abstract;
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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<IDataResult<List<Category>>> GetAllAsync()
        {
            var response = await _categoryDal.FindAllAsync();
            return new SuccessDataResult<List<Category>>(response, "Listelendi");
        }

        public async Task<IDataResult<Category>> GetByIdAsync(int id)
        {
            var response = await _categoryDal.FindByIdAsync(id);
            return new SuccessDataResult<Category>(response, "Listelendi");
        }

        public async Task<IResult> AddAsync(Category category)
        {
            await _categoryDal.CreateAsync(category);
            return new Result(true, "Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            await _categoryDal.DeleteAsync(id);
            return new Result(true, "Silme Başarılı");
        }

        public async Task<IResult> UpdateAsync(Category category)
        {
            await _categoryDal.UpdateAsync(category);
            return new Result(true, "Güncelleme Başarılı");
        }

        public async Task<IResult> IsStatus(int id)
        {
            var response = await _categoryDal.FindByIdAsync(id);
            if (response.Status == true)
            {
                response.Status = false;
            }
            else
            {
                response.Status = true;
            }
            await _categoryDal.UpdateAsync(response);
            return new Result(true, "Başarılı");
        }
    }
}
