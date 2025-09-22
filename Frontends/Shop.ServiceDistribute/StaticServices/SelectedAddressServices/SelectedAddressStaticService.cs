using Shop.ServiceDistribute.Models;
using Shop.ServiceDistribute.StaticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.StaticServices.SelectedAddressServices
{
    public class SelectedAddressStaticService : ISelectedAddressStaticService
    {
        private readonly List<SelectedAddressViewModel> _orderSummaries = new();

        public IEnumerable<SelectedAddressViewModel> GetAllSelectedAddress()
        {
            return _orderSummaries;
        }

        public void AddSelectedAddress(SelectedAddressViewModel model)
        {
            model.SelectedAddressID = 1;
            _orderSummaries.Add(model);
        }

        public void UpdateSelectedAddress(SelectedAddressViewModel updatedSelectedAddress)
        {
            var existing = _orderSummaries.FirstOrDefault(x => x.SelectedAddressID == 1);
            if (existing != null)
            {
                existing.AddressID = updatedSelectedAddress.AddressID;
            
            }
        }

        public void RemoveSelectedAddress(int id)
        {
            var existing = _orderSummaries.FirstOrDefault(x => x.SelectedAddressID == 1);
            if (existing != null)
            {
                _orderSummaries.Remove(existing);
            }

        }

    }
}
