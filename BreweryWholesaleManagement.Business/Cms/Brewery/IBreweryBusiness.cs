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
        ListBeersResponse ListBeers(ListBeersRequest request);
        AddBeerResponse AddBeer(AddBeerRequest request);
        DeleteBeerResponse DeleteBeer(DeleteBeerRequest request);
    }
}
