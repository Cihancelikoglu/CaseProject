using CaseProject.Core.Entities.Concrete;
using CaseProject.Core.Utilities.Result;
using CaseProject.Entity.Dto;
using CaseProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Abstract
{
    public interface IUserService
    {
        Task<List<OperationClaim>> GetClaims(User user);
        Task<IResult> AddAsync(User user);

        Task<User> GetByMail(string email);
    }
}
