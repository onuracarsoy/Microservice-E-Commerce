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
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public RemoveAddressCommandHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle (RemoveAddressCommand command)
        {
           var value =  await _repository.GetByIdAsync(command.ID);
            await _repository.DeleteAsync(value);

        }
    }
}
