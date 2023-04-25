using BreweryWholesaleManagement.Data.Db;
using BreweryWholesaleManagement.Models.Cms.Brewery;
using BreweryWholesaleManagement.Models.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace BreweryWholesaleManagement.Business.Cms.Brewery
{
    public class BreweryBusiness : IBreweryBusiness
    {
        private readonly IConfiguration _configuration;
        private readonly MyDbContext _context;

        public BreweryBusiness(IConfiguration Configuration, MyDbContext Context)
        {
            _configuration = Configuration;
            _context = Context;
        }
        public AddBeerResponse AddBeer(AddBeerRequest request)
        {
            AddBeerResponse response = new AddBeerResponse();

            Guid ExistingId = _context.Beers.Where(x => x.Name == request.Name && x.IsActive == true).Select(y => y.Id).FirstOrDefault();
            if (ExistingId != null && ExistingId != Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.BeerAlreadyExist;
                return response;
            }
            var beer = new Data.DbModels.Beer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                AlcoholContent = request.AlcoholContent,
                IdBrewery = request.IdBrewery,
                Price = request.Price,
                IsActive = true
            };
            _context.Beers.Add(beer);
            _context.SaveChanges();
            response.Id = beer.Id;

            if (response.Id != null && response.Id != Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.Success;
            }
            else { response.StatusCode.message = MessageDescription.CannotAddBeer; }
            return response;
        }

        public GlobalResponse CreateMock()
        {
            GlobalResponse response = new GlobalResponse();
            if (_context.Breweries.Count() == 0)
            {
                var brewery1 = new Data.DbModels.Brewery { Id =Guid.NewGuid(),Name= "Abbaye de Leffe" };
                var brewery2 = new Data.DbModels.Brewery { Id =Guid.NewGuid(),Name= "Ghost Moon Brewery" };
                var breweries = new List<Data.DbModels.Brewery> { brewery1 ,brewery2};
                _context.Breweries.AddRange(breweries);
                _context.SaveChanges();
            }
            if (_context.Wholesalers.Count() == 0)
            {
                var wholesaler1 = new Data.DbModels.Wholesaler { Id = Guid.NewGuid(), Name ="One Market" };
                var wholesaler2 = new Data.DbModels.Wholesaler { Id = Guid.NewGuid(), Name = "Fast Market" };
                var wholesalers = new List<Data.DbModels.Wholesaler> { wholesaler1, wholesaler2 };
                _context.Wholesalers.AddRange(wholesalers);
                _context.SaveChanges();
            }
            response.StatusCode.message = MessageDescription.Success; 
            return response;
        }

        public DeleteBeerResponse DeleteBeer(DeleteBeerRequest request)
        {
            DeleteBeerResponse response = new DeleteBeerResponse();

            if (request.Ids == null || request.Ids.Count < 1)
            {
                response.StatusCode.message = MessageDescription.InvalidParameter;
            }
            else 
            {
                var result = _context.Beers.Where(item => request.Ids.Contains(item.Id)).ToList();
                if (result != null)
                {
                    foreach (Data.DbModels.Beer beer in result)
                    {
                        beer.IsActive = false;
                    }
                    _context.SaveChanges();
                    response.StatusCode.message = MessageDescription.Success;
                }
                else 
                {
                    response.StatusCode.message = MessageDescription.AlreadyDeleted;
                }
            }
            return response;
        }

        public ListBeersResponse ListBeers(ListBeersRequest request)
        {
            ListBeersResponse response = new ListBeersResponse();

            response.Beers = _context.Beers.Where(x => x.IdBrewery == request.IdBrewery && x.IsActive==true).Take(request.pageSize).Skip(request.page).ToList();
            response.Brewery = _context.Breweries.Where(x => x.Id == request.IdBrewery).FirstOrDefault();
            response.TotalCount = response.Beers.Count();
            if (response.Brewery == null || response.Brewery.Id == null || response.Brewery.Id == Guid.Empty)
            { 
                response.StatusCode.message = MessageDescription.InvalidBrewery;
                return response;
            }

            if (response.Beers.Count < 1)
            {
                response.StatusCode.message = MessageDescription.Empty;
            }
            else { response.StatusCode.message = MessageDescription.Success; }
            return response;
        }

        public ListBreweriesResponse ListBreweries()
        {
            ListBreweriesResponse response = new ListBreweriesResponse();
            response.Breweries = _context.Breweries.ToList();
            response.StatusCode.message = MessageDescription.Success;
            return response;
        }

        public SellToWholesalerResponse SellToWholesaler(SellToWholesalerRequest request)
        {
            SellToWholesalerResponse response = new SellToWholesalerResponse();

            Guid ExistingIdBeer = _context.Beers.Where(x => x.Id == request.IdBeer && x.IsActive == true).Select(y => y.Id).FirstOrDefault();
            if (ExistingIdBeer == null || ExistingIdBeer == Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.InvalidBeer;
                return response;
            }
            Guid ExistingIdWholesaler = _context.Wholesalers.Where(x => x.Id == request.IdWholesaler && x.IsActive == true).Select(y => y.Id).FirstOrDefault();
            if (ExistingIdWholesaler == null || ExistingIdWholesaler == Guid.Empty)
            {
                response.StatusCode.message = MessageDescription.InvalidWholesaler;
                return response;
            }
            var result = _context.WholesalerStocks.Where(x => x.IdBeer == request.IdBeer && x.IdWholesaler == request.IdWholesaler).FirstOrDefault();

            if (result != null)
            {
                result.RemainingQuantity = result.RemainingQuantity + request.Quantity;
                _context.SaveChanges();
                response.StatusCode.message = MessageDescription.Success;
            }
            else
            {
                var wholesalerStock = new Data.DbModels.WholesalerStock
                {
                    Id = Guid.NewGuid(),
                    IdBeer=request.IdBeer,
                    IdWholesaler=request.IdWholesaler,
                    RemainingQuantity=request.Quantity
                };
                _context.WholesalerStocks.Add(wholesalerStock);
                _context.SaveChanges();
                response.StatusCode.message = MessageDescription.Success;
            }
             
            return response;
        }
    }
}
