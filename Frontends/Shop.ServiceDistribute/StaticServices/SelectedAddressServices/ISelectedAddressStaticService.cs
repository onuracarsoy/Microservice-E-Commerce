using Shop.ServiceDistribute.StaticModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ServiceDistribute.StaticServices.SelectedAddressServices
{
    public interface ISelectedAddressStaticService
    {
        public IEnumerable<SelectedAddressViewModel> GetAllSelectedAddress();
        public void AddSelectedAddress(SelectedAddressViewModel model);
        public void UpdateSelectedAddress(SelectedAddressViewModel updatedSummary);
        public void RemoveSelectedAddress(int id);
    }
}
