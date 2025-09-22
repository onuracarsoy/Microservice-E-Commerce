
using Shop.ServiceDistribute.Services.Abstract;
using System.Net;
using System.Net.Http.Headers;

namespace Shop.ServiceDistribute.Handlers
{
	public class ClientCredentialTokenHandler : DelegatingHandler
	{
		private readonly IClientCredentialTokenService _clientCredentialTokenService;

		public ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
		{
			_clientCredentialTokenService = clientCredentialTokenService;
		}
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Token'ı al ve Authorization header'ını ayarla
            var accessToken = await _clientCredentialTokenService.GetToken();
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new Exception("Access token alınamadı.");
            }

            SetAuthorizationHeader(request, accessToken);

            // İsteği gönder
            var response = await base.SendAsync(request, cancellationToken);

            // Başarılı durumları kontrol et
            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            // Hata içeriğini oku
            var errorContent = await response.Content.ReadAsStringAsync();

            // Hata mesajını oluştur ve fırlat
            var exceptionMessage = $"Hata meydana geldi!\n" +
                                   $"Hata Kodu: {response.StatusCode}\n" +
                                   $"Hata Mesajı: {errorContent}";
            throw new Exception(exceptionMessage);
        }

        // Authorization header'ını ayarlayan yardımcı metod
        private void SetAuthorizationHeader(HttpRequestMessage request, string token)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        #region Eski Yöntem
        //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        //{
        //	request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await _clientCredentialTokenService.GetToken());
        //	var response = await base.SendAsync(request, cancellationToken);
        //	if(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.NoContent)
        //	{
        //              return response;
        //          }


        //          var errorContent = await response.Content.ReadAsStringAsync();


        //          var exceptionMessage = $"Hata meydana geldi!\n" +
        //                                 $"Hata Kodu: {response.StatusCode}\n" +
        //                                 $"Hata Mesajı: {errorContent}";

        //          throw new Exception(exceptionMessage);

        //      }
        #endregion
    }
}
