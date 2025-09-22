using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingID { get; set; }

        public string UserID { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public int? CargoDetailID { get; set; }

        public int AddressID { get; set; }

        public Address Address { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

    }
}
