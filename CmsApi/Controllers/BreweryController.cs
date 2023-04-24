using BreweryWholesaleManagement.Business.Cms.Brewery;
using BreweryWholesaleManagement.Models.Cms.Brewery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BreweryController : ControllerBase
    {
        private IBreweryBusiness _breweryBusiness;
        public BreweryController(IBreweryBusiness breweryBusiness)
        { 
            _breweryBusiness = breweryBusiness;
        }
        ///<summary> 
        ///IdBrewery Required , will return success or empty
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public ListBeersResponse ListBeers(ListBeersRequest request)
        {
            return _breweryBusiness.ListBeers(request);
        }
        ///<summary> 
        ///All fields required , will return beername already used , cannot add beer or success
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public AddBeerResponse AddBeer(AddBeerRequest request)
        {
            return _breweryBusiness.AddBeer(request);
        }
        ///<summary> 
        ///Can delete multiple
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public DeleteBeerResponse DeleteBeer(DeleteBeerRequest request)
        {
            return _breweryBusiness.DeleteBeer(request);
        }
    }
}
