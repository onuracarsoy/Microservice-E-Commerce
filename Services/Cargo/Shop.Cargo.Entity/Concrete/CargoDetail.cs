using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Entity.Concrete
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }

        public string CargoDetailSenderCustomer { get; set; }

        public string CargoDetailReceiverCustomer { get; set; }

        public int OrderingID { get; set; }

        public int CargoCompanyID { get; set; }
        public CargoCompany CargoCompany { get; set; }

        public int CargoCustomerID { get; set; }
        public CargoCustomer CargoCustomer { get; set; }

        public int CargoOperationID { get; set; }
        public CargoOperation CargoOperation { get; set; }
    }
}
