namespace Shop.Discount.Dtos.CouponDtos
{
    public class ResultCouponDto
    {
        public int CouponID { get; set; }

        public string CouponCode { get; set; }

        public int CouponRate { get; set; }

        public DateTime CouponValidDate { get; set; }

        public bool CouponIsActive { get; set; }
    }
}
