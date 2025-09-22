using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.SpecialOfferDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;

namespace Shop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {

        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var value = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferID == id);
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var value = await _specialOfferCollection.Find(x => x.SpecialOfferID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(value);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSpecialOfferDto>>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferID == updateSpecialOfferDto.SpecialOfferID, values);
        }

        public async Task SpecialOfferChangeToStatusAsync(string id)
        {
            var value = await _specialOfferCollection.Find(x => x.SpecialOfferID == id).FirstOrDefaultAsync();
            value.SpecialOfferStatus = !value.SpecialOfferStatus;
            await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferID == id, value);
        }
    }
}
