using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Shop.ServiceDistribute.Dtos.IdentityDtos.LoginDtos;
using Shop.ServiceDistribute.Dtos.IdentityDtos.RegisterDtos;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Settings;
using System.Net.Http.Json;
using System.Security.Claims;

namespace Shop.ServiceDistribute.Services.Concrete
{
    public class IdentityForManagerService : IIdentityForManagerService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;
        private readonly ServiceApiSettings _serviceApiSettings;

        public IdentityForManagerService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
            _serviceApiSettings = serviceApiSettings.Value;
        }

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false,
                }
            });

            var refreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            if (string.IsNullOrEmpty(refreshToken))
            {
                return false; 
            }

            RefreshTokenRequest refreshTokenRequest = new()
            {
                ClientId = _clientSettings.ShopManagerClient.ClientID,
                ClientSecret = _clientSettings.ShopManagerClient.ClientSecret,
                RefreshToken = refreshToken,
                Address = discoveryEndPoint.TokenEndpoint
            };

          
                var token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);
            
        


            var authenticationToken = new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken 
                },

                new AuthenticationToken {

                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken

                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            };

            var result = await _contextAccessor.HttpContext.AuthenticateAsync();

            var properties = result.Properties;

            properties?.StoreTokens(authenticationToken);

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

            return true;
        }

        public async Task<bool> SignIn(UserLoginDto userLoginDto)
        {
            try
            {
                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false,
                    }
                });

                var passwordTokenRequest = new PasswordTokenRequest
                {
                    ClientId = _clientSettings.ShopManagerClient.ClientID,
                    ClientSecret = _clientSettings.ShopManagerClient.ClientSecret,
                    UserName = userLoginDto.Email,
                    Password = userLoginDto.Password,
                    Address = discoveryEndPoint.TokenEndpoint

                };

                var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

                var userInfoRequest = new UserInfoRequest
                {
                    Token = token.AccessToken,
                    Address = discoveryEndPoint.UserInfoEndpoint


                };

                var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                var authenticationProperties = new AuthenticationProperties();

                authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },

                new AuthenticationToken {

                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken

                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });

                authenticationProperties.IsPersistent = false;


                await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return false;

        }

        public async Task<bool> SignUp(UserRegisterDto userRegisterDto)
        {
            try
            {
                // IdentityServer'dan Discovery Document al
                var discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = _serviceApiSettings.IdentityServerUrl,
                    Policy = new DiscoveryPolicy
                    {
                        RequireHttps = false,
                    }
                });

                if (discoveryEndPoint.IsError)
                {
                    Console.WriteLine(discoveryEndPoint.Error);
                    return false;
                }

                // Kullanıcı kayıt isteği için HTTP POST isteği oluştur
                var response = await _httpClient.PostAsJsonAsync<UserRegisterDto>($"http://localhost:5001/api/Registers", userRegisterDto);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"SignUp Error: {await response.Content.ReadAsStringAsync()}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in SignUp: {ex}");
                return false;
            }
        }
    }
}






