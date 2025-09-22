using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.FeatureServiceDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;

namespace Shop.Catalog.Services.FeatureServices
{
    public class FeatureServiceService : IFeatureServiceService
    {

        private readonly IMongoCollection<FeatureService> _featureServiceCollection;
        private readonly IMapper _mapper;

        public FeatureServiceService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureServiceCollection = database.GetCollection<FeatureService>(_databaseSettings.FeatureServiceCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureServiceAsync(CreateFeatureServiceDto createFeatureServiceDto)
        {
            var value = _mapper.Map<FeatureService>(createFeatureServiceDto);
            await _featureServiceCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureServiceAsync(string id)
        {
            await _featureServiceCollection.DeleteOneAsync(x => x.FeatureServiceID == id);
        }

        public async Task<GetByIdFeatureServiceDto> GetByIdFeatureServiceAsync(string id)
        {
            var value = await _featureServiceCollection.Find(x => x.FeatureServiceID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureServiceDto>(value);
        }

        public async Task<List<ResultFeatureServiceDto>> GetAllFeatureServiceAsync()
        {
            var values = await _featureServiceCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureServiceDto>>(values);
        }

        public async Task UpdateFeatureServiceAsync(UpdateFeatureServiceDto updateFeatureServiceDto)
        {
            var values = _mapper.Map<FeatureService>(updateFeatureServiceDto);
            await _featureServiceCollection.FindOneAndReplaceAsync(x => x.FeatureServiceID == updateFeatureServiceDto.FeatureServiceID, values);
        }
    }
}
