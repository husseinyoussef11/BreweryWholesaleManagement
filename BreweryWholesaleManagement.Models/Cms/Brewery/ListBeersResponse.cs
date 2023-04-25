using BreweryWholesaleManagement.Data.DbModels;
using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Brewery
{
    public class ListBeersResponse : GlobalResponse
    {
        public List<Beer> Beers { get; set; } = new List<Beer>();
        public Data.DbModels.Brewery Brewery { get; set; } = new Data.DbModels.Brewery();
        public int TotalCount { get; set; }
    }
}
