using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Cargo.Dto.CargoOperationDtos
{
    public class UpdateCargoOperationDto
    {
        public int CargoOperationID { get; set; }

        public string CargoOperationBarcode { get; set; }

        public bool CargoStepOne { get; set; }

        public bool CargoStepTwo { get; set; }

        public bool CargoStepThree { get; set; }

        public bool CargoStepFour { get; set; }

        public bool CargoStepFive { get; set; }

        public string CargoOperationDescription { get; set; }

        public DateTime CargoOperationDate { get; set; }
    }
}
