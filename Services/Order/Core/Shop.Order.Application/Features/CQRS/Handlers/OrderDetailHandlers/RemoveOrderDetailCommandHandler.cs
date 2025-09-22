using AutoMapper;
using Shop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.ID);
            await _repository.DeleteAsync(value);
        }
    }
}
