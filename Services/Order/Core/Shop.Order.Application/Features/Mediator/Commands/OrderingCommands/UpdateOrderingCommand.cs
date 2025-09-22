using MediatR;
using Shop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class UpdateOrderingCommand : IRequest
    {
        public int OrderingID { get; set; }

        public string UserID { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public int AddressID { get; set; }

        public int? CargoDetailID { get; set; }


    }
}
