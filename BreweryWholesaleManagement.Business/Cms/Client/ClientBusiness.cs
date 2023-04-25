using BreweryWholesaleManagement.Data.Db;
using BreweryWholesaleManagement.Models.Cms.Client;
using BreweryWholesaleManagement.Models.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Business.Cms.Client
{
    public class ClientBusiness : IClientBusiness
    {
        private readonly IConfiguration _configuration;
        private readonly MyDbContext _context;

        public ClientBusiness(IConfiguration Configuration, MyDbContext Context)
        {
            _configuration = Configuration;
            _context = Context;
        }

        public RequestQuoteResponse RequestQuote(RequestQuoteRequest request)
        {
            RequestQuoteResponse response = new RequestQuoteResponse();
            if (request.Quantity < 1) 
            {
                response.StatusCode.message = MessageDescription.OrderEmpty;
                return response;
            }
            Guid ExistingIdWholesaler = _context.Wholesalers.Where(x => x.Id == request.IdWholesaler && x.IsActive == true).Select(y => y.Id).FirstOrDefault();
            if (ExistingIdWholesaler == null || ExistingIdWholesaler == Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.InvalidWholesaler;
                return response;
            }
            var wholesalerstock= _context.WholesalerStocks.Where(x => x.IdBeer == request.IdBeer && x.IdWholesaler == request.IdWholesaler).FirstOrDefault();
            if (wholesalerstock == null || wholesalerstock.Id == Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.BeerNotRelatedToWholesaler;
                return response;
            }

            if (wholesalerstock.RemainingQuantity < request.Quantity) 
            {
                response.StatusCode.message = MessageDescription.OrderLargerThanStock;
                return response;
            }

            var clientOrder = _context.ClientOrders.Where(x => x.IdBeer == request.IdBeer && x.IdWholesaler == request.IdWholesaler).FirstOrDefault();
            if (clientOrder != null && clientOrder.Id != Guid.Empty)  
            {
                response.StatusCode.message = MessageDescription.DuplicateOrder;
                return response;
            }

            var beer = _context.Beers.Where(x => x.Id == request.IdBeer && x.IsActive ==true).FirstOrDefault();
            if (beer == null || beer.Id == Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.InvalidBeer;
                return response;
            }

            float discount = 0;
            float finalPrice = beer.Price * request.Quantity;

            if (request.Quantity > 10 && request.Quantity < 21)
            {
                discount = 10;
                finalPrice = finalPrice - 10 * 100 / finalPrice;
            }
            else if (request.Quantity > 20)
            {
                discount = 20;
                finalPrice = finalPrice - 20 * 100 / finalPrice;
            }

            Random rnd = new Random();
            var order = new Data.DbModels.ClientOrder
            {
                Id = Guid.NewGuid(),
                OrderReference = rnd.Next(52).ToString(),
                IdBeer=request.IdBeer,
                IdWholesaler=request.IdWholesaler,
                Quantity = request.Quantity,
                price= finalPrice
            };
            _context.ClientOrders.Add(order);
            _context.SaveChanges();

            response.Quantity = request.Quantity;
            response.DiscountPercentage = discount;
            response.Price = finalPrice;
            response.OrderReference = order.OrderReference;
            response.StatusCode.message = MessageDescription.Success;
            return response;
        }
    }
}
