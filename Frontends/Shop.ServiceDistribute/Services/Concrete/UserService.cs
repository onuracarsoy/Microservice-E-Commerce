using Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos;
using Shop.ServiceDistribute.Dtos.IdentityDtos.UserDtos;
using Shop.ServiceDistribute.Model;
using Shop.ServiceDistribute.Services.Abstract;
using System.Net.Http.Json;

namespace Shop.ServiceDistribute.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteUser(string userId)
        {
             await _httpClient.DeleteAsync($"/api/users/DeleteUser?userId={userId}");
        }

        public async Task<List<UserDetailViewModel>> GetAllUserList()
        {
           var values =  await _httpClient.GetFromJsonAsync<List<UserDetailViewModel>>("/api/users/GetAllUserList");
            return values;
        }

        public async Task<UserDetailViewModel> GetByUserIdWithUserInfo(string userId)
        {
            var responseMessage = await _httpClient.GetAsync($"api/users/GetByUserIdWithUserInfo?userId={userId}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UserDetailViewModel>();
            return value;
        }

        public async Task<UpdateUserDto> GetUserForUpdateInfo()
        {
            return await _httpClient.GetFromJsonAsync<UpdateUserDto>("/api/users/getuserinfo");
        }

        public async  Task<UserDetailViewModel> GetUserInfo()
        {
            return await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuserinfo");
        }

        public async Task<HttpResponseMessage> UpdateUserInfo(UpdateUserDto updateUserDto)
        {
           var responseMessage = await _httpClient.PutAsJsonAsync<UpdateUserDto>("/api/users/UpdateUserInfo", updateUserDto);

            return responseMessage;
        }
    }
}
