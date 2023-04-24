using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Data.DbModels
{
    public class Log
    { 
       [Key]
       public Guid Id { get; set; }
       public string? Machine { get; set; }
       public string? Level { get; set; } 
       public string? Logger { get; set; } 
       public string? Message { get; set; }   
       public string? RequestPath { get; set; }   
       public string? Headers { get; set; }    
       public string? RequestBody { get; set; }    
       public string? Response { get; set; }   
       public string? Exception { get; set; }   
       public string? StackTrace { get; set; }   
       public string? ExecutionTime { get; set; }   
       public string? IP { get; set; }   
       public string? RequestMethod { get; set; }   
       public string? RequestContentType { get; set; }   
       public string? Created { get; set; }   
       public string? BaseLink { get; set; }   
    }
}
