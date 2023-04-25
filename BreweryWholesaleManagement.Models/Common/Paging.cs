using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Common
{
    public class Paging
    {
        [System.ComponentModel.DefaultValue(0)]
        [Range(0, int.MaxValue)]
        public int page { get; set; }
        [System.ComponentModel.DefaultValue(10)]
        [Range(1, int.MaxValue)]
        public int pageSize { get; set; }
        public string search { get; set; } = String.Empty;
    }
}
