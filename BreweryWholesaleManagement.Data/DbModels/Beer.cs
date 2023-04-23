using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Data.DbModels
{
    public class Beer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float AlcoholContent { get; set; }
        public float Price { get; set; }
        public Guid IdBrewery { get; set; } 
        public bool IsActive { get; set; }  
    }
}
