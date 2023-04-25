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
        ///To be used one time to create wholesalers and breweries
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public BreweryWholesaleManagement.Models.Common.GlobalResponse CreateMock()
        {
            return _breweryBusiness.CreateMock();
        }
        ///<summary> 
        ///Additional api to get breweries
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpGet]
        public ListBreweriesResponse ListBreweries()
        {
            return _breweryBusiness.ListBreweries();
        }
        ///<summary> 
        /// FR1 --------IdBrewery Required , will return Success or empty
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpGet]
        public ListBeersResponse ListBeers([FromQuery]ListBeersRequest request)
        {
            return _breweryBusiness.ListBeers(request);
        }
        ///<summary> 
        /// FR2 ---------All fields required , will return beername already used , cannot add beer or Success
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public AddBeerResponse AddBeer(AddBeerRequest request)
        {
            return _breweryBusiness.AddBeer(request);
        }
        ///<summary> 
        /// FR3 ---------- Can delete multiple , will return Success or AlreadyDeleted
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpDelete]
        public DeleteBeerResponse DeleteBeer(DeleteBeerRequest request)
        {
            return _breweryBusiness.DeleteBeer(request);
        }
        ///<summary> 
        /// FR4 ------------ Update if stock exist or create new stock , will return Success or InvalidBeer or InvalidWholesaler
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public SellToWholesalerResponse SellToWholesaler(SellToWholesalerRequest request)
        {
            return _breweryBusiness.SellToWholesaler(request);
        }
    }
}
