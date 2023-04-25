using BreweryWholesaleManagement.Models.Cms.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Business.Cms.Client
{
    public interface IClientBusiness
    {
        RequestQuoteResponse RequestQuote(RequestQuoteRequest request);
    }
}
