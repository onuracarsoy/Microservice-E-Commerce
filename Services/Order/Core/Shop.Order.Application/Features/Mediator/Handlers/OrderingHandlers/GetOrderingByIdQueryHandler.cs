using AutoMapper;
using MediatR;
using Shop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using Shop.Order.Application.Features.Mediator.Results.OrderingResults;
using Shop.Order.Application.Interfaces;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
           var value =  await _repository.GetByIdAsync(request.ID);
            return _mapper.Map<GetOrderingByIdQueryResult>(value);

        }
    }
}
