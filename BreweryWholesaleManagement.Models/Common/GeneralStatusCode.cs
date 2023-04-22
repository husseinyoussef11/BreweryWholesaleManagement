using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Common
{
    public class GlobalResponse
    {
        public GeneralStatusCode StatusCode { get; set; }

        public GlobalResponse()
        {
            StatusCode = new GeneralStatusCode();
        }

    }
    public class GeneralStatusCode
    { 
        public string message { get; set; }
    }
}
