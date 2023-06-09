﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryWholesaleManagement.Models.Common
{
    public class MessageDescription
    {
        public const string ServerError = "Oops!! An Error Occured Please Contact Support";
        public const string Success = "Success";
        public const string InvalidParameter = "Invalid Input";
        public const string CannotAddBeer = "Beer Cannot Be Added";
        public const string BeerAlreadyExist = "Beer Name Already Used";
        public const string Empty = "Empty";
        public const string AlreadyDeleted = "AlreadyDeleted";
        public const string InvalidBrewery = "InvalidBrewery";
        public const string InvalidBeer = "Invalid Beer";
        public const string InvalidWholesaler = "The wholesaler must exist";
        public const string OrderEmpty = "The order cannot be empty";
        public const string BeerNotRelatedToWholesaler = "The beer must be sold by the wholesaler";
        public const string OrderLargerThanStock = "The number of beers ordered cannot be greater than the wholesaler's stock";
        public const string DuplicateOrder = "There can't be any duplicate in the order";
    }
}
