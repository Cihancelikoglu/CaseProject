using CaseProject.Core.DataAccess.Dapper;
using CaseProject.Core.DataAccess.Dapper.Context;
using CaseProject.Core.Entities.Concrete;
using CaseProject.Data.Abstract;
using CaseProject.Entity.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace CaseProject.Data.Concrete
{
    public class UserDal : Repository<User>, IUserDal
    {
        public UserDal(DatabaseSettings dbSettings)
            : base(dbSettings) { }

        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            DbConnection.Open();
            try
            {
                string sql = "SELECT OperationClaims.Id, OperationClaims.Name  FROM OperationClaims INNER JOIN UserOperationClaims ON UserOperationClaims.UserId = " + user.Id + ";";
                var result = DbConnection.Query<OperationClaim>(sql);
                //var result = from operationClaim in context.OperationClaims
                //             join userOperationClaim in context.UserOperationClaims
                //                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                //             where userOperationClaim.UserId == user.Id
                //             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
            finally { DbConnection.Close(); }


        }
    }
}
