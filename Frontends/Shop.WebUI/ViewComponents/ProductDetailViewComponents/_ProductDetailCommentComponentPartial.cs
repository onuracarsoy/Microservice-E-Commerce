using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Services.ReviewServices.CommentServices;


namespace Shop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailCommentComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public _ProductDetailCommentComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string ProductID)
        {

            var value = await _commentService.GetCommentByProductID(ProductID);
            return View(value);


        }
    }
}
