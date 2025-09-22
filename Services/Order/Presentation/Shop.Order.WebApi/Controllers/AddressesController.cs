using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Shop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using Shop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace Shop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;
        private readonly GetAddressByUserIdQueryHandler _getAdressByUserIdQueryHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler,
            GetAddressByIdQueryHandler getAddressByIdQueryHandler,
            CreateAddressCommandHandler createAddressCommandHandler,
            UpdateAddressCommandHandler updateAddressCommandHandler,
            RemoveAddressCommandHandler removeAddressCommandHandler,
            GetAddressByUserIdQueryHandler getAdressByUserIdQueryHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _getAdressByUserIdQueryHandler = getAdressByUserIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpGet("AddressListByUserId")]
        public async Task<IActionResult>AddressListByUserId(string userID)
        {
            var value = await _getAdressByUserIdQueryHandler.Handle(new GetAddressByUserIdQuery(userID));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command); 
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok();
        }
    }
}
