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
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ID);
            await _repository.DeleteAsync(value);
        }
    }
}
