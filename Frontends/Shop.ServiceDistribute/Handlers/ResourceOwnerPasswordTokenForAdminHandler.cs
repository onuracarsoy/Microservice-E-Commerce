using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Shop.ServiceDistribute.Handlers
{
    public class ResourceOwnerPasswordTokenForAdminHandler  : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IIdentityForAdminService _identityForAdminService;

        public ResourceOwnerPasswordTokenForAdminHandler(IHttpContextAccessor httpContextAccessor, IdentityForAdminService identityService)
        {
            _httpContextAccessor = httpContextAccessor;
            _identityForAdminService = identityService;
        }



        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Access token al ve doğrula
            var accessToken = await GetAccessTokenAsync();
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Access token alınamadı.");
            }

            // İlk isteği gönder
            SetAuthorizationHeader(request, accessToken);
            var response = await base.SendAsync(request, cancellationToken);

            // Eğer yetkisiz ise token yenile ve tekrar dene
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var newAccessToken = await RefreshAccessTokenAsync();
                if (!string.IsNullOrEmpty(newAccessToken))
                {
                    SetAuthorizationHeader(request, newAccessToken);
                    response = await base.SendAsync(request, cancellationToken);
                }
            }

            // Başarılı durumları döndür
            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            // Hata mesajını oluştur ve fırlat
            var errorContent = await response.Content.ReadAsStringAsync();
            var exceptionMessage = $"Hata meydana geldi!\n" +
                                   $"Hata Kodu: {response.StatusCode}\n" +
                                   $"Hata Mesajı: {errorContent}";
            throw new Exception(exceptionMessage);
        }

        // Access token almayı yöneten metod
        private async Task<string> GetAccessTokenAsync()
        {
            return await _httpContextAccessor.HttpContext?.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
        }

        private async Task<string> RefreshAccessTokenAsync()
        {
            // GetRefreshToken bir boolean döndürüyor; işlem başarılı mı diye kontrol ediyoruz.
            var isTokenRefreshed = await _identityForAdminService.GetRefreshToken();

            if (isTokenRefreshed)
            {
                // Eğer yenileme başarılıysa, yeni access token'ı bir başka metoddan veya kaynaktan almanız gerekiyor.
                return await GetAccessTokenAsync();// Örneğin bir GetAccessToken metodu.
            }

            // Yenileme başarısızsa null döndürüyoruz.
            return null;
        }

        // Authorization header'ı ayarlayan metod
        private void SetAuthorizationHeader(HttpRequestMessage request, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

    
    }
}
