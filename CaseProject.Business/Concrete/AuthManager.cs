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

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>("Kullanıcı Bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>("Şifre Hatalı");
            }

            return new SuccessDataResult<User>(userToCheck, "Giriş Başarılı");
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
            await _userService.AddAsync(user);
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
    }
}
