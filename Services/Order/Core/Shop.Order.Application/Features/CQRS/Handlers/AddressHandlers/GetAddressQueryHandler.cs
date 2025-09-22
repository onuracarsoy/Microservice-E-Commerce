using AutoMapper;
using Shop.Order.Application.Features.CQRS.Results.AddressResults;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetAddressQueryResult>>(values).ToList();
        }
    }
}
