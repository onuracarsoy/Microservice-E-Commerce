using AutoMapper;
using Shop.Order.Application.Features.CQRS.Queries.AddressQueries;
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
    public class GetAddressByUserIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        private readonly IMapper _mapper;

        public GetAddressByUserIdQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAddressByUserIdQueryResult>> Handle(GetAddressByUserIdQuery query)
        {
            var value = await _repository.GetByUserIdForAddressAsync(query.UserID);
            return _mapper.Map<List<GetAddressByUserIdQueryResult>>(value);
        }
    }
}
