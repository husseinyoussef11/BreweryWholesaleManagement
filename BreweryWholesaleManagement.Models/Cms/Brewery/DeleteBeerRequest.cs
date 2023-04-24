using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Brewery
{
    public class DeleteBeerRequest
    {
        public List<Guid> Ids { get; set; } = new List<Guid>();
    }
}
