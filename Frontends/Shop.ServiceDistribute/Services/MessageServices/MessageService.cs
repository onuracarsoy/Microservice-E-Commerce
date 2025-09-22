using Shop.ServiceDistribute.Dtos.MessageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateMessageDto>("messages",createMessageDto);
        }

        public async Task DeleteMessageAsync(int id)
        {
            await _httpClient.DeleteAsync($"messages?id={id}");
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var responseMessage = await _httpClient.GetAsync("messages");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultMessageDto>>();

            return values;
        }

        public async Task<List<InboxMessageDto>> GetInboxMessageAsync(string receiverID)
        {
            var responseMessage = await _httpClient.GetAsync($"messages/GetInboxMessage?receiverID={receiverID}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<InboxMessageDto>>();

            return values;
        }

        public async Task<List<SendboxMessageDto>> GetSendboxMessageAsync(string senderID)
        {
            var responseMessage = await _httpClient.GetAsync($"messages/GetInboxMessage?senderID={senderID}");
            var values = await responseMessage.Content.ReadFromJsonAsync<List<SendboxMessageDto>>();

            return values;
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateMessageDto>("messages", updateMessageDto);
        }
    }
}
