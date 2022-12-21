using CaseProject.Core.DataAccess;
using CaseProject.Entity.Entities;
using System.Linq.Expressions;

namespace CaseProject.Data.Abstract
{
    public interface IProductDal : IRepository<Product>
    {
        
    }
}
