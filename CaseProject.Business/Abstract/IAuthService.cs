using CaseProject.Core.Utilities.Result;
using CaseProject.Core.Utilities.Security.JWT;
using CaseProject.Entity.Dto;
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
        Task<IResult> UserExists(string email);
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
