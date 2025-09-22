using AutoMapper;
using Shop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
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
    public class GetOrderDetailQueryHandler
    {

        private readonly IRepository<OrderDetail> _repository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetOrderDetailQueryResult>>(values).ToList();
        }
    }
}
