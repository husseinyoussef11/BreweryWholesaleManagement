using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Client
{
    public class RequestQuoteResponse:GlobalResponse
    {
        public float Price { get; set; }
        public float DiscountPercentage { get; set; }
        public int Quantity { get; set; }
        public string OrderReference { get; set; }

    }
}
