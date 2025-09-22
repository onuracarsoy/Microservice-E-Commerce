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
    public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery,List<GetOrderingByUserIdQueryResult>>
    {
        private readonly IRepository<Ordering> _repository;
        private readonly IMapper _mapper;

        public GetOrderingByUserIdQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByUserIdForOrderingAsync(request.UserID);
            return _mapper.Map<List<GetOrderingByUserIdQueryResult>>(value);

        }
    }
}
