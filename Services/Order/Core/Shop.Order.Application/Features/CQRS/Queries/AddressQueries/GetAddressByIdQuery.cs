using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery
    {
        public GetAddressByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
