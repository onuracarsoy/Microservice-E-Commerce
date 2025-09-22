using AutoMapper;
using MediatR;
using Shop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderingCommand command, CancellationToken cancellationToken)
        {
            var value =  _mapper.Map<Ordering>(command);
            await _repository.UpdateAsync(value);
        }
    }
}
