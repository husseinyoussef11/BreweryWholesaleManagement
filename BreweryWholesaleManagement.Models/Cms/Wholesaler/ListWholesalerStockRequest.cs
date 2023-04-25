using BreweryWholesaleManagement.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Wholesaler
{
    public class ListWholesalerStockRequest :Paging
    {
        [Required]
        public Guid IdWholesaler { get; set; }
    }
}
