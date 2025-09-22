using Shop.ServiceDistribute.Models;
using Shop.ServiceDistribute.StaticServices.OrderSummaryServices;
using System.Runtime.CompilerServices;

namespace Shop.ServiceDistribute.StaticServices
{
    public class OrderSummaryStaticService : IOrderSummaryStaticService
    {
        private readonly List<OrderSummaryViewModel> _orderSummaries = new();

        public IEnumerable<OrderSummaryViewModel> GetAllSummaries()
        {
            return _orderSummaries;
        }

        public void AddSummary(OrderSummaryViewModel model)
        {
            model.OrderSummaryID = 1;
            _orderSummaries.Add(model);
        }

        public void UpdateSummary(OrderSummaryViewModel updatedSummary)
        {
            var existing = _orderSummaries.FirstOrDefault(x => x.OrderSummaryID == 1);
            if (existing != null)
            {
                existing.TotalPrice = updatedSummary.TotalPrice;
                existing.SubTotalPrice = updatedSummary.SubTotalPrice;
                existing.CouponConfirmStatus = updatedSummary.CouponConfirmStatus;
                existing.DiscountAmount = updatedSummary.DiscountAmount;
                existing.KDVAmount = updatedSummary.KDVAmount;
                existing.KDVWithTotalPrice = updatedSummary.KDVWithTotalPrice;
            }
        }

        public void RemoveSummary(int id)
        {
            var existing = _orderSummaries.FirstOrDefault(x => x.OrderSummaryID == 1);
            if (existing != null)
            {
                _orderSummaries.Remove(existing);
            }

        }
    }
}
