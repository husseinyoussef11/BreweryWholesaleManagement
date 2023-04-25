using BreweryWholesaleManagement.Models.Cms.Brewery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Business.Cms.Brewery
{
    public interface IBreweryBusiness
    {
        ListBreweriesResponse ListBreweries();
        ListBeersResponse ListBeers(ListBeersRequest request);
        AddBeerResponse AddBeer(AddBeerRequest request);
        DeleteBeerResponse DeleteBeer(DeleteBeerRequest request);
        SellToWholesalerResponse SellToWholesaler(SellToWholesalerRequest request);
        BreweryWholesaleManagement.Models.Common.GlobalResponse CreateMock();
    }
}
