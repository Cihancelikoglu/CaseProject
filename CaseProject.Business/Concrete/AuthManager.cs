using CaseProject.Business.Abstract;
using CaseProject.Business.Constants;
using CaseProject.Core.Utilities.Result;
using CaseProject.Core.Utilities.Security.Hashing;
using CaseProject.Data.Abstract;
using CaseProject.Data.Concrete;
using CaseProject.Entity.Dto;
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
        IUserService _userService;

        public AuthManager(IUserService userService)
        {
            _userService = userService;
        }

        public Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                Surname = userForRegisterDto.Surname,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.AddAsync(user);
            return new SuccessDataResult<User>(user, "Kullanıcı Kayıt Başarılı");
        }

        public async Task<IResult> UserExists(string email)
        {
            var response = await _userService.GetByMail(email);

            if (response != null)
            {
                return new ErrorResult("Kullanıcı Mevcut");
            }
            return new SuccessResult();
        }




        //public async Task<IDataResult<User>> GetByIdAsync(int id)
        //{
        //    var response = await _userDal.FindByIdAsync(id);
        //    return new SuccessDataResult<User>(response, "Listelendi");
        //}

        //public async Task<IDataResult<User>> Login(string mail, string password)
        //{
        //    var userCheck = await _userDal.GetFilter(x => x.Email == mail && x.Password == password);
        //    if (userCheck == null)
        //    {
        //        return new ErrorDataResult<User>("Kullanıcı Adı veya Şifre Hatalı");
        //    }
        //    return new SuccessDataResult<User>(userCheck, "Giriş Başarılı");
        //}

        //public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        //{
        //    byte[] passwordHash, passwordSalt;
        //    HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        //    var user = new User
        //    {
        //        Email = userForRegisterDto.Email,
        //        Name = userForRegisterDto.Name,
        //        Surname = userForRegisterDto.Surname,
        //        PasswordHash = passwordHash,
        //        PasswordSalt = passwordSalt,
        //        Status = true
        //    };
        //    _userDal.CreateAsync(user);
        //    return await new SuccessDataResult<User>(user, "Kullanıcı Başarıyla Kayıt Edildi");
        //}
    }
}
