using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Settings;

namespace Shop.ServiceDistribute.Services.Concrete
{
	public class ClientCredentialTokenService : IClientCredentialTokenService
	{
		private readonly ServiceApiSettings _serviceApiSettings;
		private readonly HttpClient _httpClient;
		private readonly IClientAccessTokenCache _clientAccessTokenCache;
		private readonly ClientSettings _clientSettings;

		public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
		{
			_serviceApiSettings = serviceApiSettings.Value;
			_httpClient = httpClient;
			_clientAccessTokenCache = clientAccessTokenCache;
			_clientSettings = clientSettings.Value;
		}

		public async Task<string> GetToken()
		{
			var currentToken = await _clientAccessTokenCache.GetAsync("shoptoken");
			if (currentToken != null)
			{
				return currentToken.AccessToken;
			}

			var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
			{
				Address = _serviceApiSettings.IdentityServerUrl,
				Policy = new DiscoveryPolicy
				{
					RequireHttps = false,
				}
			});

			
			var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
			{
				ClientId = _clientSettings.ShopVisitorClient.ClientID,
				ClientSecret = _clientSettings.ShopVisitorClient.ClientSecret,
				Address = discoveryEndPoint.TokenEndpoint
				//GrantType = "client_credentials"

			};

			var newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
			await _clientAccessTokenCache.SetAsync("shoptoken", newToken.AccessToken, newToken.ExpiresIn);
			return newToken.AccessToken;


		}
	}
}
