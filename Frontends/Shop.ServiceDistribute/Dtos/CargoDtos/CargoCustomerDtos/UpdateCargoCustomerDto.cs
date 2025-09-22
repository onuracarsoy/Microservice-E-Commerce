﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Dtos.CargoDtos.CargoCustomer
{
    public class UpdateCargoCustomerDto
    {
        public int CargoCustomerID { get; set; }

        public string CargoCustomerName { get; set; }

        public string CargoCustomerSurname { get; set; }

        public string CargoCustomerEmail { get; set; }

        public string CargoCustomerPhone { get; set; }

        public string CargoCustomerDistrict { get; set; }

        public string CargoCustomerCity { get; set; }

        public string CargoCustomerAddress { get; set; }
    }
}
