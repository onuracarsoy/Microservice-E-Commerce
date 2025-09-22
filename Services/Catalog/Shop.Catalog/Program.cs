
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using Shop.Catalog.Services.CategoryServices;
using Shop.Catalog.Services.ContactServices;
using Shop.Catalog.Services.FeatureServices;
using Shop.Catalog.Services.FeatureSliderServices;
using Shop.Catalog.Services.ProductDetailServices;
using Shop.Catalog.Services.ProductImageServices;
using Shop.Catalog.Services.ProductServices;
using Shop.Catalog.Services.SpecialOfferServices;
using Shop.Catalog.Services.StatisticServices;
using Shop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;

});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureServiceService, FeatureServiceService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
