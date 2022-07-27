using DKMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Models.ViewModels
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Products = new Products();
        }
        public Products Products { get; set; }
        public bool ExistsInCart { get; set; }
    }
}
