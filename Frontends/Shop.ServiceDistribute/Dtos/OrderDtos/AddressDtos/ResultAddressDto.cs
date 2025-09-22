using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Dtos.OrderDtos.AddressDtos
{
    public class ResultAddressDto
    {
        public int AddressID { get; set; }

        public string UserID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string AddressDistrict { get; set; }

        public string AddressCity { get; set; }

        public string AddressDetail { get; set; }

        public string ZipCode { get; set; }
    }
}
