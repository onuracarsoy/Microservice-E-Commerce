using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.IdentityDtos.UserDtos;
using Shop.ServiceDistribute.Model;

namespace Shop.ServiceDistribute.Services.Abstract
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
        Task<UserDetailViewModel> GetByUserIdWithUserInfo(string userId);
        Task<UpdateUserDto> GetUserForUpdateInfo();
        Task<HttpResponseMessage> UpdateUserInfo(UpdateUserDto updateUserDto);
        Task<List<UserDetailViewModel>> GetAllUserList();
        Task DeleteUser(string userId);
        
    }
}
