using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.FeatureSliderDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;
using static MongoDB.Driver.WriteConcern;

namespace Shop.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly IMongoCollection<FeatureSlider> _featureSliderCollection;
        private readonly IMapper _mapper;

        public FeatureSliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _featureSliderCollection = database.GetCollection<FeatureSlider>(_databaseSettings.FeatureSliderCollectionName);
            _mapper = mapper;
        }

        public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = _mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await _featureSliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _featureSliderCollection.DeleteOneAsync(x => x.FeatureSliderID == id);
        }

        public async Task<GetByIdFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await _featureSliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var values = _mapper.Map<FeatureSlider>(updateFeatureSliderDto);
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == updateFeatureSliderDto.FeatureSliderID, values);
        }

        public async Task FeatureSliderChangeToStatusAsync(string id)
        {
            var value = await _featureSliderCollection.Find(x => x.FeatureSliderID == id).FirstOrDefaultAsync();
            value.FeatureSliderStatus = !value.FeatureSliderStatus;
            await _featureSliderCollection.FindOneAndReplaceAsync(x => x.FeatureSliderID == id, value);
        }
    }
}
