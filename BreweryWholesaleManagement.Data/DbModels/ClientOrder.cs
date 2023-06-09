﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Data.DbModels
{
    public class ClientOrder
    { 
        [Key]
        public Guid Id { get; set; }
        public string OrderReference { get; set; }
        public Guid IdBeer { get; set; } 
        public Guid IdWholesaler { get; set; }
        public int Quantity { get; set; }
        public float price { get; set; }
        public string Created { get; set; }
    }
}
