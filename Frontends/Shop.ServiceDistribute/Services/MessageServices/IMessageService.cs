using Shop.ServiceDistribute.Dtos.MessageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Services.MessageServices
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
