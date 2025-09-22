using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.ReviewDtos.CommentDtos;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.CatalogServices.ProductServices;
using Shop.ServiceDistribute.Services.ReviewServices.CommentServices;


using System.Text;
using X.PagedList.Extensions;

namespace Shop.WebUI.Controllers
{
    public class ProductListController : Controller
    {


        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;

        public ProductListController(IUserService userService, IProductService productService, ICommentService commentService)
        {
            _userService = userService;
            _productService = productService;
            _commentService = commentService;
        }

        public async Task<IActionResult> AllProductList(int page = 1)
        {
            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Products");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            var values = await _productService.GetAllProductAsync();
            var pagedValues = values.ToPagedList(page,9);
            return View(pagedValues);
        }

        [Route("ProductList/ProductListByCategory/{categoryID}")]
        public async Task<IActionResult> ProductListByCategory(string CategoryID, int page =1)
        {
            var values = await _productService.GetProductWihCategoryByCategoryIDAsync(CategoryID);
            var pagedValues = values.ToPagedList(page, 9);
            return View(pagedValues);


        }

        [HttpGet]
        [Route("ProductList/ProductDetail/{productID}")]
        public IActionResult ProductDetail(string ProductID, CreateCommentDto createCommentDto)
        {
            ViewBag.ProductID = ProductID;
            ViewBag.CreateComment = createCommentDto;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PostComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostComment(CreateCommentDto createCommentDto)
        {
            var user= await _userService.GetUserInfo();
            createCommentDto.CommentCreateDate = DateTime.Now;
            createCommentDto.CommentNameSurname = user.Name + " " + user.Surname;
            createCommentDto.CommentEmail = user.Email;
            await _commentService.CreateComment(createCommentDto);
            return View($"/ProductList/ProductDetail/{createCommentDto.ProductID}");

        }


    }
}
