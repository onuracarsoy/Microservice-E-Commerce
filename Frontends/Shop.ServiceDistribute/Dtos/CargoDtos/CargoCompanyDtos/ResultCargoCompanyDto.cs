using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.Dtos.CargoDtos.CargoCompanyDtos
{
    public class ResultCargoCompanyDto
    {
        public int CargoCompanyID { get; set; }

        public string CargoCompanyName { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
