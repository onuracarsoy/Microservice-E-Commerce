namespace Shop.ServiceDistribute.Dtos.DiscountDtos.CouponDtos
{
    public class CreateCouponDto
    {
        public string CouponCode { get; set; }

        public int CouponRate { get; set; }

        public DateTime CouponValidDate { get; set; }

        public bool CouponIsActive { get; set; }
    }
}
