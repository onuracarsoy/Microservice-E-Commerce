using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Queries.OrderDetailQueries
{
    public class GetOrderDetailByOrderingIdQuery
    {
        public GetOrderDetailByOrderingIdQuery(int id)
        {
            OrderID = id;
        }

        public int OrderID { get; set; }
    }
}
