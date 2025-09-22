using AutoMapper;
using Shop.Order.Application.Features.CQRS.Commands.AddressCommands;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            var value = _mapper.Map<Address>(createAddressCommand);
            await _repository.CreateAsync(value);
        }
    }
}
