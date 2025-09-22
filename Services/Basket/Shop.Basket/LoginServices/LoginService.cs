using System.Security.Claims;

namespace Shop.Basket.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public string GetUserID
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext == null)
                {
                    throw new Exception("HttpContext mevcut değil.");
                }

                var user = httpContext.User;
                if (user == null || !user.Identity.IsAuthenticated)
                {
                    throw new Exception("Kullanıcı kimlik doğrulaması yapılmamış.");
                }

                var userIdClaim = user.FindFirst("sub");
                if (userIdClaim == null)
                {
                    throw new Exception("'sub' claim'i bulunamadı.");
                }

                return userIdClaim.Value;
            }
        }
    }
}
