using CaseProject.Core.DataAccess;
using CaseProject.Core.Entities.Concrete;
using CaseProject.Entity.Entities;
using System.Linq.Expressions;

namespace CaseProject.Data.Abstract
{
    public interface IUserDal : IRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
    }
}
