using AutoMapper;
using Shop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Shop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByOrderingIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByOrderingIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderDetailByOrderingIdQueryResult>> Handle(GetOrderDetailByOrderingIdQuery getOrderDetailByOrderingIdQuery)
        {
            var value = await _repository.GetByOrderingIdAsync(getOrderDetailByOrderingIdQuery.OrderID);
            return _mapper.Map<List<GetOrderDetailByOrderingIdQueryResult>>(value);
        }
    }
}
