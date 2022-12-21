using CaseProject.Core.Utilities.Result;
using CaseProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> GetByIdAsync(int id);
        Task<IDataResult<User>> Register(User user);
        Task<IDataResult<User>> Login(string mail, string password);
    }
}
