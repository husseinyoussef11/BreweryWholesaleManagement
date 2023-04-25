using BreweryWholesaleManagement.Business.Cms.Wholesaler;
using BreweryWholesaleManagement.Models.Cms.Wholesaler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        private IWholesalerBusiness _wholesalerBusiness;
        public WholesalerController(IWholesalerBusiness wholesalerBusiness)
        {
            _wholesalerBusiness = wholesalerBusiness;
        }
        ///<summary> 
        ///IdWholesaler Required , return stock of wholesaler
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpGet]
        public ListWholesalerStockResponse ListWholesalerStock([FromQuery]ListWholesalerStockRequest request)
        {
            return _wholesalerBusiness.ListWholesalerStock(request);
        }
        ///<summary> 
        ///Additional api to get Wholesalers
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpGet]
        public ListWholesalersResponse ListWholesalers()
        {
            return _wholesalerBusiness.ListWholesalers();
        }

        ///<summary> 
        /// FR5 -------------- A stock should exist to update it
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPut]
        public UpdateWholesalerStockResponse UpdateWholesalerStock(UpdateWholesalerStockRequest request)
        {
            return _wholesalerBusiness.UpdateWholesalerStock(request);
        }
    }
}
