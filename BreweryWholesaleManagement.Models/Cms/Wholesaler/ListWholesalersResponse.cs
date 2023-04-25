using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Wholesaler
{
    public class ListWholesalersResponse : GlobalResponse
    {
        public List<Data.DbModels.Wholesaler> Wholesalers { get; set; } = new List<Data.DbModels.Wholesaler> { };
    }
}
