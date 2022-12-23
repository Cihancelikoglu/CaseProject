using CaseProject.Core.DataAccess.Dapper;
using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Data.Abstract;
using CaseProject.Entity.Dto;
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
    public class ProductDal : Repository<Product>, IProductDal
    {
        public ProductDal(DatabaseSettings dbSettings)
            : base(dbSettings) { }
    }
}
