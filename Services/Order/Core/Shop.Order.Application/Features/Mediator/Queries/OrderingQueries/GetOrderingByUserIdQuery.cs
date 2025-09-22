using MediatR;
using Shop.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingByUserIdQuery : IRequest<List<GetOrderingByUserIdQueryResult>>
    {
        public GetOrderingByUserIdQuery(string id)
        {
            UserID = id;
        }

        public string UserID { get; set; }
    }
}
