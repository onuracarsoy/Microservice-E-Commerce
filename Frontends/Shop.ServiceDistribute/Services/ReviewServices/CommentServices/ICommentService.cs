using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Dtos.ReviewDtos.CommentDtos;

namespace Shop.ServiceDistribute.Services.ReviewServices.CommentServices
{
    public interface ICommentService
    {
        Task CommentChangeToStatus(int id);
        Task<List<ResultCommentDto>> CommentList();
        Task CreateComment(CreateCommentDto createCommentDto);
        Task DeleteComment(int id);
        Task<GetByIdCommentDto> GetComment(int id);
        Task<List<ResultCommentDto>> GetCommentByProductID(string ProductID);
        Task UpdateComment(UpdateCommentDto updateCommentDto);
        Task<UpdateCommentDto> GetByIdCommentForUpdateAsync(int id);
    }
}
