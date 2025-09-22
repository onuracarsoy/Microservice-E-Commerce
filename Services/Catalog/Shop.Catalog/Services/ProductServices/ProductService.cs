using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.ProductDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace Shop.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);

        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);

        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);

        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, value);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            var result = _mapper.Map<List<ResultProductWithCategoryDto>>(products);
            foreach (var item in result)
            {
                var category = categories.FirstOrDefault(x => x.CategoryID == item.CategoryID);
                item.CategoryName = category.CategoryName;

            }
            return result;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWihCategoryByCategoryIDAsync(string CategoryID)
        {

            var products = await _productCollection.Find(x =>x.CategoryID == CategoryID).ToListAsync();
            var categories = await _categoryCollection.Find(x => true).ToListAsync();

            var result = _mapper.Map<List<ResultProductWithCategoryDto>>(products);
            foreach (var item in result)
            {
                var category = categories.FirstOrDefault(x => x.CategoryID == item.CategoryID);
                item.CategoryName = category.CategoryName;

            }
            return result;
        }
    }
}
