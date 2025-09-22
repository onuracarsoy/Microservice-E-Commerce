using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Shop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("OrderingListByUserId")]
        public async Task<IActionResult> OrderingListByUserId(string userId)
        {
            var value = await _mediator.Send(new GetOrderingByUserIdQuery(userId));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
           var value =  await _mediator.Send(command);
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
