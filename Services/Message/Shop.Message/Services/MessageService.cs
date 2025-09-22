using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Message.Dal.Context;
using Shop.Message.Dal.Entities;
using Shop.Message.Dtos;

namespace Shop.Message.Services
{
    public class MessageService : IMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public MessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var model = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(model);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<List<InboxMessageDto>> GetInboxMessageAsync(string receiverID)
        {
            var values = await _messageContext.UserMessages.Where(x=>x.MessageReceiverID == receiverID).ToListAsync();
            return _mapper.Map<List<InboxMessageDto>>(values);
        }

        public async Task<List<SendboxMessageDto>> GetSendboxMessageAsync(string senderID)
        {
            var values = await _messageContext.UserMessages.Where(x => x.MessageSenderID == senderID).ToListAsync();
            return _mapper.Map<List<SendboxMessageDto>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var model = _mapper.Map<UserMessage>(updateMessageDto);
            _messageContext.UserMessages.Update(model);
            await _messageContext.SaveChangesAsync();
        }
    }
}
