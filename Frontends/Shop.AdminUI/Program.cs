using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Shop.AdminUI.Components;

using Shop.ServiceDistribute.Handlers;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.CargoServices.CargoCompanyServices;
using Shop.ServiceDistribute.Services.CargoServices.CargoCustomerServices;
using Shop.ServiceDistribute.Services.CargoServices.CargoDetailServices;
using Shop.ServiceDistribute.Services.CargoServices.CargoOperationService;
using Shop.ServiceDistribute.Services.CatalogServices.CategoryServices;
using Shop.ServiceDistribute.Services.CatalogServices.ContactServices;
using Shop.ServiceDistribute.Services.CatalogServices.FeatureServiceServices;
using Shop.ServiceDistribute.Services.CatalogServices.ProductDetailServices;
using Shop.ServiceDistribute.Services.CatalogServices.ProductImageServices;
using Shop.ServiceDistribute.Services.CatalogServices.ProductServices;
using Shop.ServiceDistribute.Services.CatalogServices.SliderServices;
using Shop.ServiceDistribute.Services.CatalogServices.SpecialOfferServices;
using Shop.ServiceDistribute.Services.Concrete;
using Shop.ServiceDistribute.Services.DiscountServices.CouponServices;
using Shop.ServiceDistribute.Services.OrderServices.AddressServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingDetailServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingServices;
using Shop.ServiceDistribute.Services.ReviewServices.CommentServices;

using Shop.ServiceDistribute.Settings;
using System.Net.Http;
using System.Text;


var builder = WebApplication.CreateBuilder(args);





// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

#region CustomAuthProvider Yöntemi
//// CustomAuthenticationStateProvider servis kaydý
//builder.Services.AddScoped<CustomAuthenticationStateProvider>();

//// Blazor'ýn AuthenticationStateProvider olarak kullanabilmesi için arayüz kaydý
//// CustomAuthenticationStateProvider servis kaydý
//builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
//    provider.GetRequiredService<CustomAuthenticationStateProvider>());
//builder.Services.AddAuthorization();


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = "http://localhost:5001",       
//        ValidAudience = "https://localhost:7176",   
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ShopJwt")) // Güçlü bir anahtar kullanýn
//    };
//});
#endregion

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
//{
//    opt.LoginPath = "/Login";
//    opt.LogoutPath = "/Login";
//    opt.AccessDeniedPath = "/AccessDenied";
//    opt.Cookie.HttpOnly = true;
//    opt.Cookie.SameSite = SameSiteMode.Strict;
//    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
//    opt.Cookie.Name = "ShopJwt";

//});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login";
        opt.AccessDeniedPath = "/AccessDenied";
        opt.ExpireTimeSpan = TimeSpan.FromDays(5);
        opt.Cookie.Name = "ShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();



builder.Services.AddHttpClient<IIdentityForAdminService, IdentityForAdminService>();
builder.Services.AddScoped<IdentityForAdminService>();



builder.Services.Configure<ClientSettings>(
    builder.Configuration.GetSection("ClientSettings"));

builder.Services.Configure<ServiceApiSettings>(
    builder.Configuration.GetSection("ServiceApiSettings"));



builder.Services.AddScoped<ResourceOwnerPasswordTokenForAdminHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();



var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);

}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();


#region CatalogServices
builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IFeautreServiceService, FeatureServiceService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();



#endregion

#region ReviewServices
builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Review.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();
#endregion

#region DiscountServices


builder.Services.AddHttpClient<ICouponService, CouponService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();
#endregion

#region OrderServices

builder.Services.AddHttpClient<IOrderingService, OrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IOrderingDetailService, OrderingDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<IAddressService, AddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

#endregion

#region CargoServices

builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<ICargoDetailService, CargoDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

builder.Services.AddHttpClient<ICargoOperationService, CargoOperationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForAdminHandler>();

#endregion





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseAntiforgery();



app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
