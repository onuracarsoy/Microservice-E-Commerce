using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.ReviewDtos.CommentDtos;
using System.Net.Http.Json;
using System.Text;

namespace Shop.ServiceDistribute.Services.ReviewServices.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CommentChangeToStatus(int id)
        {

            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");


            await _httpClient.PutAsync($"comments/CommentChangeToStatus?id={id}", content);

        }

        public Task<List<ResultCommentDto>> CommentList()
        {
            throw new NotImplementedException();
        }

        public async Task CreateComment(CreateCommentDto createCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDto>("comments",createCommentDto);
        }

        public async Task DeleteComment(int id)
        {
            await _httpClient.DeleteAsync($"comments?id={id}");
        }

        public async Task<UpdateCommentDto> GetByIdCommentForUpdateAsync(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return value;
        }

        public async Task<GetByIdCommentDto> GetComment(int id)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdCommentDto>();
            return value;
        }

        public async Task<List<ResultCommentDto>> GetCommentByProductID(string ProductID)
        {
            var responseMessage = await _httpClient.GetAsync($"Comments/GetCommentByProductID?ProductID={ProductID}");
            var value = await responseMessage.Content.ReadFromJsonAsync<List<ResultCommentDto>>();
            return value;
        }

        public async Task UpdateComment(UpdateCommentDto updateCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }
    }
}
