using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Cms.Brewery
{
    public class AddBeerRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Range(0,float.MaxValue)]
        public float AlcoholContent { get; set; }
        [Range(0, float.MaxValue)]
        public float Price { get; set; }
        [Required]
        public Guid IdBrewery { get; set; }
    }
}
