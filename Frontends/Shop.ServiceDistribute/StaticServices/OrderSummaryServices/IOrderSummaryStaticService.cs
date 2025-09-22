using Shop.ServiceDistribute.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.StaticServices.OrderSummaryServices
{
    public interface IOrderSummaryStaticService
    {
        public IEnumerable<OrderSummaryViewModel> GetAllSummaries();
        public void AddSummary(OrderSummaryViewModel model);
        public void UpdateSummary(OrderSummaryViewModel updatedSummary);
        public void RemoveSummary(int id);
    }
}
