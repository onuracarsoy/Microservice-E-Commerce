using Shop.Message.Dtos;

namespace Shop.Message.Services
{
    public interface IMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<InboxMessageDto>> GetInboxMessageAsync(string receiverID);
        Task<List<SendboxMessageDto>> GetSendboxMessageAsync(string senderID);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
    }
}
