using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByUserIdQuery
    {
        public GetAddressByUserIdQuery(string userID)
        {
            UserID = userID;
        }

        public string UserID { get; set; }
    }
}
