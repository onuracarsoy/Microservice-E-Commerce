using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Review.Context;
using Shop.Review.Entities;

namespace Shop.Review.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly ReviewContext _reviewContext;

        public CommentsController(ReviewContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _reviewContext.Comments.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var value = await _reviewContext.Comments.FindAsync(id);
            return Ok(value);
        }

        [HttpGet("GetCommentByProductID")]
        public async Task<IActionResult> GetCommentByProductID(string ProductID)
        {
            var values = await _reviewContext.Comments.Where(x => x.ProductID == ProductID).OrderByDescending(x=>x.CommentCreateDate).ToListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            var value = _reviewContext.Comments.Add(comment);
            await _reviewContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(Comment comment)
        {
            var value = _reviewContext.Comments.Update(comment);
            await _reviewContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("CommentChangeToStatus")]
        public async Task<IActionResult> CommentChangeToStatus(int id)
        {
            var value = _reviewContext.Comments.Find(id);
            value.CommentStatus = !value.CommentStatus;
            _reviewContext.Comments.Update(value);
            await _reviewContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var value = _reviewContext.Comments.Find(id);
            _reviewContext.Comments.Remove(value);
            await _reviewContext.SaveChangesAsync();
            return Ok();
        }
    }
}
