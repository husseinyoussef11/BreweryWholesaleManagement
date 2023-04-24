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
        ///Working
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public ListBeersResponse ListBeers(ListBeersRequest request)
        {
            return _breweryBusiness.ListBeers(request);
        }
        ///<summary> 
        ///Working
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public AddBeerResponse AddBeer(AddBeerRequest request)
        {
            return _breweryBusiness.AddBeer(request);
        }
        ///<summary> 
        ///Working
        ///</summary>
        ///<remarks>  
        ///</remarks>
        //[HttpPost]
        //public DeleteBeerResponse DeleteBeer(DeleteBeerRequest request)
        //{
        //    return _breweryBusiness.DeleteBeer(request);
        //}
    }
}
