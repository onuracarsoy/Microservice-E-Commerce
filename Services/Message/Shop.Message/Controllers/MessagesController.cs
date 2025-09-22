using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Message.Dtos;
using Shop.Message.Services;

namespace Shop.Message.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllMessage()
        {
            var values = await _messageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpGet("GetInboxMessage")]
        public async Task<IActionResult> GetInboxMessage(string receiverID)
        {
            var values = await _messageService.GetInboxMessageAsync(receiverID);
            return Ok(values);
        }

        [HttpGet("GetSendboxMessage")]
        public async Task<IActionResult> GetSendboxMessage(string senderID)
        {
            var values = await _messageService.GetSendboxMessageAsync(senderID);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDto createMessageDto)
        {
           await _messageService.CreateMessageAsync(createMessageDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            await _messageService.DeleteMessageAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            await _messageService.UpdateMessageAsync(updateMessageDto);
            return Ok();
        }
    }
}
