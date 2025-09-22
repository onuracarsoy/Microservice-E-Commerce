namespace Shop.ServiceDistribute.Models
{
    public class OrderSummaryViewModel
    {
        public int OrderSummaryID { get; set; }
        public decimal? SubTotalPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? KDVAmount { get; set; }
        public decimal? KDVWithTotalPrice { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string? CouponConfirmStatus { get; set; }
     
       
    }
}
