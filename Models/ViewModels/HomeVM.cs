using DKMart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Products> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
