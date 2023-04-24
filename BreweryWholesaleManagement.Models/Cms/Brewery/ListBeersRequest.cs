using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Brewery
{
    public class ListBeersRequest : Paging
    {
        [Required]
        public Guid IdBrewery { get; set; }
    }
}
