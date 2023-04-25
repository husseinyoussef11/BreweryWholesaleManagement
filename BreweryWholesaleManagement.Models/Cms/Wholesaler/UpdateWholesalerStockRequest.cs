using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Wholesaler
{
    public class UpdateWholesalerStockRequest
    {
        [Required]
        public Guid IdWholesaler { get; set; }
        [Required]
        public Guid IdBeer { get; set; }
        [DefaultValue(50)]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
