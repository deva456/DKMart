using DKMart.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Models.ViewModels
{
    public class ProductsVM
    {
        public Products Products { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
    }
}
