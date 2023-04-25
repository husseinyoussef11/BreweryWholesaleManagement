using BreweryWholesaleManagement.Data.Db;
using BreweryWholesaleManagement.Models.Cms.Wholesaler;
using BreweryWholesaleManagement.Models.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Business.Cms.Wholesaler
{
    public class WholesalerBusiness : IWholesalerBusiness
    {
        private readonly IConfiguration _configuration;
        private readonly MyDbContext _context;

        public WholesalerBusiness(IConfiguration Configuration, MyDbContext Context)
        {
            _configuration = Configuration;
            _context = Context;
        }

        public ListWholesalersResponse ListWholesalers()
        {
            ListWholesalersResponse response = new ListWholesalersResponse();
            response.Wholesalers = _context.Wholesalers.ToList(); 
            response.StatusCode.message = MessageDescription.Success;
            return response;
        } 

        public ListWholesalerStockResponse ListWholesalerStock(ListWholesalerStockRequest request)
        {
            ListWholesalerStockResponse response = new ListWholesalerStockResponse();
            Guid ExistingIdWholesaler = _context.Wholesalers.Where(x => x.Id == request.IdWholesaler && x.IsActive == true).Select(y => y.Id).FirstOrDefault();
            if (ExistingIdWholesaler == null || ExistingIdWholesaler == Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.InvalidWholesaler;
                return response;
            }

            var query = from w in _context.WholesalerStocks
                        join b in _context.Beers on w.IdBeer equals b.Id
                        where b.IsActive == true
                        select new WholesalerStock() { BeerName=b.Name,IdBeer=w.IdBeer,Quantity=w.RemainingQuantity };
            response.stock = query.Take(request.pageSize).Skip(request.page).ToList();
            response.TotalCount = response.stock.Count();
            response.wholesaler = _context.Wholesalers.Where(x => x.Id == request.IdWholesaler && x.IsActive==true).FirstOrDefault();
            response.StatusCode.message = MessageDescription.Success;
            return response;

        }
    }
}
