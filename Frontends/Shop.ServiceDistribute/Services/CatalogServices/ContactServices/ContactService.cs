using Newtonsoft.Json;
using Shop.ServiceDistribute.Dtos.CatalogDtos.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;

        public ContactService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task ContactChangeToReadStatusAsync(string id)
        {
            var content = new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json");


            await _httpClient.PutAsync($"contacts/ContactChangeToReadStatus?id={id}", content);
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            if(createContactDto is not null)
            {
               await _httpClient.PostAsJsonAsync<CreateContactDto>("contacts", createContactDto);
            }
          
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync($"contacts?id={id}");

        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var responseMessage = await _httpClient.GetAsync("contacts");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultContactDto>>();

            return values;
        }

        public async Task<GetByIdContactDto> GetByIdContactAsync(string id)
        {

            var responseMessage = await _httpClient.GetAsync($"contacts/{id}");
            var value = await responseMessage.Content.ReadFromJsonAsync<GetByIdContactDto>();
            return value;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contacts", updateContactDto);

        }

    }
}
