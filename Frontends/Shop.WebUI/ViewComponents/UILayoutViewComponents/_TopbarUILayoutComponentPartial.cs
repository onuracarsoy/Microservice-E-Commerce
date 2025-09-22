using Microsoft.AspNetCore.Mvc;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.Concrete;
using Shop.WebUI.Models;

namespace Shop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial : ViewComponent
    {
       
        public IViewComponentResult Invoke()
        {
            //bool isAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            //var result = new AuthenticationModel()
            //{
            //    AuthStatus = isAuthenticated
            //};
            return View(/*result*/);
        }
    }
}
