using BreweryWholesaleManagement.Models.Cms.Wholesaler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Business.Cms.Wholesaler
{
    public interface IWholesalerBusiness
    {
        ListWholesalerStockResponse ListWholesalerStock(ListWholesalerStockRequest request);
        ListWholesalersResponse ListWholesalers();
    }
}
