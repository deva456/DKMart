
using DKMart.Data;
using DKMart.Models;
using DKMart.Models.ViewModels;
using DKMart.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DKSuperMarketDbContext _hdb;
        public HomeController(ILogger<HomeController> logger, DKSuperMarketDbContext hdb)
        {
            _logger = logger;
            _hdb = hdb;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Products = _hdb.Products.Include(u => u.Category),
                Categories = _hdb.Category
            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult details(int ProductId)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }

            DetailsVM detailsVM= new DetailsVM()
            {
                Products = _hdb.Products.Include(u => u.Category).Where(u => u.ProductId == ProductId).FirstOrDefault(),
                ExistsInCart = false
            };


            foreach (var item in shoppingCartList)
            {
                if (item.ProductId == ProductId)
                {
                    detailsVM.ExistsInCart = true;
                }
            }
            return View(detailsVM);
        }

        [HttpPost,ActionName("Details")]
        public IActionResult detailsPost(int ProductId)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart)!=null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count()>0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }
            shoppingCartList.Add(new ShoppingCart { ProductId = ProductId });
            HttpContext.Session.Set(WC.SessionCart, shoppingCartList);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult removeFromCart(int ProductId)
        {
            List<ShoppingCart> shoppingCartList = new List<ShoppingCart>();
            if (HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart) != null
                && HttpContext.Session.Get<IEnumerable<ShoppingCart>>(WC.SessionCart).Count() > 0)
            {
                shoppingCartList = HttpContext.Session.Get<List<ShoppingCart>>(WC.SessionCart);
            }
            var itemToRemove = shoppingCartList.SingleOrDefault(r => r.ProductId == ProductId);
            if (itemToRemove != null)
            {
                shoppingCartList.Remove(itemToRemove);
            }
            HttpContext.Session.Set(WC.SessionCart, shoppingCartList);
            return RedirectToAction(nameof(Index));
        }
    }
}
