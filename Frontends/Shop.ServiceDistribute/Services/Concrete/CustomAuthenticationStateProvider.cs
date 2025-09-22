using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Shop.ServiceDistribute.Services.Concrete
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser;

        public CustomAuthenticationStateProvider()
        {
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // Giriş yapılmış kullanıcı varsa onu döndür, yoksa anonim kullanıcıyı döndür
            return Task.FromResult(new AuthenticationState(_currentUser ?? new ClaimsPrincipal(new ClaimsIdentity())));
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            // Kullanıcı adını güvenli bir şekilde al
            var userClaim = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "Username");
            if (userClaim == null)
            {
                // Hata yönetimi, kullanıcı adı yok
                throw new InvalidOperationException("Kullanıcı adı bulunamadı.");
            }

            var userName = userClaim.Value; // Kullanıcı adını al
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, userName),
        new Claim("Token", token)
    };

            var claimsIdentity = new ClaimsIdentity(claims, "custom");
            _currentUser = new ClaimsPrincipal(claimsIdentity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
        }



        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            _currentUser = anonymousUser;

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymousUser)));
        }

    }
}
