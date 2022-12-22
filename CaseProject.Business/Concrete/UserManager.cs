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
    public class UserManager : IUserService
    {
        readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> AddAsync(User user)
        {
            await _userDal.CreateAsync(user);
            return new Result(true, "Kayıt Başarılı");
        }

        public async Task<User> GetByMail(string email)
        {
            return await _userDal.GetFilter(u => u.Email == email);
        }
    }
}
