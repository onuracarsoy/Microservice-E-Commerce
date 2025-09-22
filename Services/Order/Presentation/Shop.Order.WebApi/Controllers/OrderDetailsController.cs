using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Shop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace Shop.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailByOrderingIdQueryHandler _getOrderDetailByOrderingIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler,
            GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler,
            GetOrderDetailByOrderingIdQueryHandler getOrderDetailByOrderingIdQueryHandler,
            CreateOrderDetailCommandHandler createOrderDetailCommandHandler,
            UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler,
            RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
            _getOrderDetailByOrderingIdQueryHandler = getOrderDetailByOrderingIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetaiListById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("OrderDetailListByOrderingId")]
        public async Task<IActionResult> OrderDetailListByOrderingId(int orderingID)
        {
            var value = await _getOrderDetailByOrderingIdQueryHandler.Handle(new GetOrderDetailByOrderingIdQuery(orderingID));
            return Ok(value);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok();
        }
    }
}
