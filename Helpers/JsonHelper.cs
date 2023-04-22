using BreweryWholesaleManagement.Models.Common;
using Newtonsoft.Json;

namespace Helpers
{
    public static class JsonHelper
    {
        public static string getStatusCodeJson(string message)
        {
            return JsonConvert.SerializeObject(new GlobalResponse
            {
                StatusCode = new GeneralStatusCode
                { 
                    message = message
                }
            });
        }
    }
}