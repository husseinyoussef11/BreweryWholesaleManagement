using BreweryWholesaleManagement.Models.Cms.Brewery;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cms.UnitTest.Apis
{
    public class Calls
    {
        string cmsHost = "localhost:7121"; 
        public ListBreweriesResponse CallApiListBreweries()
        {
            ListBreweriesResponse apiresp = new ListBreweriesResponse();
            string host = cmsHost;
            string uri = string.Concat("http://", host, "/api/Brewery/ListBreweries");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "application/json";
            request.Method = "GET"; 
            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            using (StreamReader streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                apiresp = JsonConvert.DeserializeObject<ListBreweriesResponse>(result);
            }

            return apiresp;
        }
    }
}
