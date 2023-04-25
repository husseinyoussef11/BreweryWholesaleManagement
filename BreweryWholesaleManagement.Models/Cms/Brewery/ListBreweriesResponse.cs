using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Brewery
{
    public class ListBreweriesResponse : GlobalResponse
    {
        public List<Data.DbModels.Brewery> Breweries { get; set; } = new List<Data.DbModels.Brewery>();
    }
}
