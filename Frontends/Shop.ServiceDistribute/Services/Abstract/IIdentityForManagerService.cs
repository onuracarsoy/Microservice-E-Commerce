using Shop.ServiceDistribute.Dtos.IdentityDtos.LoginDtos;
using Shop.ServiceDistribute.Dtos.IdentityDtos.RegisterDtos;

namespace Shop.ServiceDistribute.Services.Abstract
{
    public interface IIdentityForManagerService
    {
        public Task<bool> SignIn(UserLoginDto userLoginDto);
        public Task<bool> SignUp(UserRegisterDto userRegisterDto);
        public Task<bool> GetRefreshToken();
    }
}
