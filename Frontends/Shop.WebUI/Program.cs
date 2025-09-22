using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.Razor;
using Shop.ServiceDistribute.Handlers;
using Shop.ServiceDistribute.Services.Abstract;
using Shop.ServiceDistribute.Services.BasketServices;
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
using Shop.ServiceDistribute.Services.MessageServices;
using Shop.ServiceDistribute.Services.OrderServices.AddressServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingDetailServices;
using Shop.ServiceDistribute.Services.OrderServices.OrderingServices;
using Shop.ServiceDistribute.Services.ReviewServices.CommentServices;
using Shop.ServiceDistribute.Settings;
using Shop.ServiceDistribute.StaticServices;
using Shop.ServiceDistribute.StaticServices.OrderSummaryServices;
using Shop.ServiceDistribute.StaticServices.SelectedAddressServices;
using Shop.WebUI.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

#region StaticServices
builder.Services.AddSingleton<IOrderSummaryStaticService, OrderSummaryStaticService>();
builder.Services.AddSingleton<ISelectedAddressStaticService, SelectedAddressStaticService>();
#endregion

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/SignIn";
        opt.AccessDeniedPath = "/AccessDenied";
        opt.ExpireTimeSpan = TimeSpan.FromDays(5);
        opt.Cookie.Name = "ShopCookie";
        opt.SlidingExpiration = true;
    });

builder.Services.AddAccessTokenManagement();

builder.Services.AddHttpContextAccessor();



builder.Services.AddHttpClient<IIdentityForManagerService, IdentityForManagerService>();
builder.Services.AddScoped<IdentityForManagerService>();



builder.Services.Configure<ClientSettings>(
    builder.Configuration.GetSection("ClientSettings"));

builder.Services.Configure<ServiceApiSettings>(
    builder.Configuration.GetSection("ServiceApiSettings"));



builder.Services.AddScoped<ResourceOwnerPasswordTokenForManagerHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();



var values = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();



builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri(values.IdentityServerUrl);

}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();


#region CatalogServices

builder.Services.AddHttpClient<ICategoryService, CategoryService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductService, ProductService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IFeautreServiceService, FeatureServiceService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<IContactService, ContactService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();
#endregion

#region ReviewServices

builder.Services.AddHttpClient<ICommentService, CommentService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Review.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

#endregion

#region BasketServices

//handler deðiþecek
builder.Services.AddHttpClient<IBasketService, BasketService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

#endregion

#region DiscountServices

//handler deðiþecek
builder.Services.AddHttpClient<ICouponService, CouponService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();
#endregion

#region OrderServices

builder.Services.AddHttpClient<IAddressService, AddressService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

builder.Services.AddHttpClient<IOrderingService, OrderingService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

builder.Services.AddHttpClient<IOrderingDetailService, OrderingDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

#endregion

#region MessageServices

builder.Services.AddHttpClient<IMessageService, MessageService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

#endregion

#region CargoServices

builder.Services.AddHttpClient<ICargoCompanyService, CargoCompanyService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

builder.Services.AddHttpClient<ICargoCustomerService, CargoCustomerService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

builder.Services.AddHttpClient<ICargoDetailService, CargoDetailService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

builder.Services.AddHttpClient<ICargoOperationService, CargoOperationService>(opt =>
{
    opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
}).AddHttpMessageHandler<ResourceOwnerPasswordTokenForManagerHandler>();

#endregion



builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "Resources";
});

builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}





app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

var supportedCulters = new[] { "tr","en" };

var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCulters[0])
    .AddSupportedCultures(supportedCulters)
    .AddSupportedUICultures(supportedCulters);

app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Profile}/{action=MyProfile}/{id?}"
    );
});



app.Run();
