using CaseProject.Business.Abstract;
using CaseProject.Core.Utilities.Result;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;
using CaseProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseProject.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserDal _userDal;
        public AuthManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IDataResult<User>> GetByIdAsync(int id)
        {
            var response = await _userDal.FindByIdAsync(id);
            return new SuccessDataResult<User>(response, "Listelendi");
        }

        public async Task<IDataResult<User>> Login(string mail, string password)
        {
            var response = await _userDal.FindAllAsync();

            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
