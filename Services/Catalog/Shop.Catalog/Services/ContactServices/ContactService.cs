using AutoMapper;
using MongoDB.Driver;
using Shop.Catalog.Dtos.ContactDtos;
using Shop.Catalog.Entities;
using Shop.Catalog.Settings;

namespace Shop.Catalog.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        private readonly IMapper _mapper;

        public ContactService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
            _mapper = mapper;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _contactCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _contactCollection.DeleteOneAsync(x => x.ContactID == id);
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdContactDto>(value);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _contactCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == updateContactDto.ContactID, values);
        }

        public async Task ContactChangeToReadStatusAsync(string id)
        {
            var value = await _contactCollection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
            value.ContactIsRead = !value.ContactIsRead;
            await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == id, value);
        }
    }
}

