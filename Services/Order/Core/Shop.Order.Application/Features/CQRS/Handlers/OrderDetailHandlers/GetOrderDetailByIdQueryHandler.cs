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
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
        {
           var value =  await _repository.GetByIdAsync(getOrderDetailByIdQuery.ID);
            return _mapper.Map<GetOrderDetailByIdQueryResult>(value);
        }
    }
}
