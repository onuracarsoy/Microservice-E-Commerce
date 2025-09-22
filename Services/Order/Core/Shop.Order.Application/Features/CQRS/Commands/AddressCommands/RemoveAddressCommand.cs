using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand
    {
        public RemoveAddressCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
