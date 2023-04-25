using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Wholesaler
{
    public class ListWholesalerStockResponse : GlobalResponse
    {
        public Data.DbModels.Wholesaler wholesaler { get; set; }
        public List<WholesalerStock> stock { get; set; }
        public int TotalCount { get; set; }
    }
    public class WholesalerStock 
    {
        public int Quantity { get; set; }
        public string BeerName { get; set; }
        public Guid IdBeer { get; set; }
    }
}
