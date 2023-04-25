using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Client
{
    public class RequestQuoteRequest
    {
        public Guid IdBeer { get; set; }
        public Guid IdWholesaler { get; set; }
        public int Quantity { get; set; }
    }
}
