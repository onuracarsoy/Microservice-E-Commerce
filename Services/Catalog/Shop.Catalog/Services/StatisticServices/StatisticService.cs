using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;

namespace Shop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public StatisticService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<long> TotalCategoryCount()
        {
            var value = await _categoryCollection.Find(x => true).CountAsync();
            return value;
        }

        public async Task<long> TotalProductCount()
        {
            var value = await _productCollection.Find(x => true).CountAsync();
            return value;
        }
    }
}
