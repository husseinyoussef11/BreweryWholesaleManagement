using BreweryWholesaleManagement.Business.Cms.Client;
using BreweryWholesaleManagement.Models.Cms.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CmsApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientBusiness _clientBusiness;
        public ClientController(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }
        ///<summary> 
        /// FR6 ---------
        ///</summary>
        ///<remarks>  
        ///</remarks>
        [HttpPost]
        public RequestQuoteResponse RequestQuote(RequestQuoteRequest request)
        {
            return _clientBusiness.RequestQuote(request);
        }
    }
}
