using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Dto.CargoDetailDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailID { get; set; }

        public string CargoDetailSenderCustomer { get; set; }

        public string CargoDetailReceiverCustomer { get; set; }

        public int OrderingID { get; set; }

        public int CargoCompanyID { get; set; }


        public int CargoCustomerID { get; set; }


        public int CargoOperationID { get; set; }


    }
}
