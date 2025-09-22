using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Discount.Dtos.CouponDtos
{
    public class GetCouponCodeDetailByCode
    {
        public int CouponID { get; set; }

        public string CouponCode { get; set; }

        public int CouponRate { get; set; }

        public DateTime CouponValidDate { get; set; }

        public bool CouponIsActive { get; set; }
    }
}
