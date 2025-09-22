using Shop.ServiceDistribute.Dtos.IdentityDtos.LoginDtos;
using Shop.ServiceDistribute.Dtos.IdentityDtos.RegisterDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.Abstract
{
    public interface IIdentityForAdminService
    {
        public Task<bool> SignIn(UserLoginDto userLoginDto);
        public Task<bool> SignUp(UserRegisterDto userRegisterDto);
        public Task<bool> GetRefreshToken();
    }
}
