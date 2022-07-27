
using DKMart.Data;
using DKMart.Models;
using DKMart.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DKSuperMarketDbContext _pdB;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public ProductsController(DKSuperMarketDbContext pB, IWebHostEnvironment WebHostEnvironment)
        {
            _pdB = pB;
            _WebHostEnvironment = WebHostEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<Products> ObjList = _pdB.Products;
            foreach (var obj in ObjList)
            {
                obj.Category = _pdB.Category.FirstOrDefault(u => u.CatId == obj.CatId);
            }
            return View(ObjList);
        }
        //GET - Upsert
        public IActionResult Upsert(int?productId)
        {
            ProductsVM productsVM = new ProductsVM()
            {
                Products=new Products(),
                CategorySelectList = _pdB.Category.Select(i => new SelectListItem
                {
                    Text = i.CatName,
                    Value = i.CatId.ToString()
                })

            };
            if (productId == null)
            {
                return View(productsVM);
            }

            else
            {
                productsVM.Products = _pdB.Products.Find(productId);
                if (productsVM.Products == null) {
                    return NotFound();
                }
                return View(productsVM);
            }
            
        }


        //POST - Upsert
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Upsert(ProductsVM productsVM)
        {

           
            if (ModelState.IsValid)
            {
                //var files = HttpContext.Request.Form.Files;
                //string webRootPath = _WebHostEnvironment.WebRootPath;

                if (productsVM.Products.ProductId==0)
                {
                    //creating
                    //string upload = webRootPath + WC.ImagePath;
                    //string fileName = Guid.NewGuid().ToString();
                    //string extension = Path.GetExtension(files[0].FileName);

                    //using (var fileStream =new FileStream(Path.Combine(upload,fileName+extension),FileMode.Create))
                    //{
                    //    files[0].CopyTo(fileStream);
                    //}
                    //productsVM.Products.image = fileName + extension;
                    _pdB.Products.Add(productsVM.Products);
                   
                }
                else
                {
                    //updating
                   //var objFromDb = _pdB.Products.AsNoTracking().FirstOrDefault(u => u.ProductId == productsVM.Products.ProductId);
                    //if (files.Count > 0)
                    //{
                    //    string upload = webRootPath + WC.ImagePath;
                    //    string fileName = Guid.NewGuid().ToString();
                    //    string extension = Path.GetExtension(files[0].FileName);

                    //    var oldFile = Path.Combine(upload, objFromDb.image);

                    //    if (System.IO.File.Exists(oldFile))
                    //    {
                    //        System.IO.File.Delete(oldFile);
                    //    }
                    //    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    //    {
                    //        files[0].CopyTo(fileStream);
                    //    }
                    //    productsVM.Products.image = fileName + extension;
                    //}
                    //else
                    //{
                    //    productsVM.Products.image = objFromDb.image;
                    //}

                    _pdB.Products.Update(productsVM.Products);
                }
                _pdB.SaveChanges();
                return RedirectToAction("Index");
            }
            productsVM.CategorySelectList = _pdB.Category.Select(i => new SelectListItem
            {
                Text = i.CatName,
                Value = i.CatId.ToString()
            });
            return View(productsVM);
        }


        //GET - Delete
        public IActionResult Delete(int? ProductId)
        {
            if (ProductId == null || ProductId == 0)
            {
                return NotFound();
            }
            Products products = _pdB.Products.Include(u=>u.Category).FirstOrDefault(u=>u.ProductId==ProductId);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }
        //POST - Delete
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteProd(int?productId)
        {
            if(productId==null|| productId == 0)
            {
                return NotFound();
            }
            var obj = _pdB.Products.Find(productId);
            if (obj!=null)
            {
                string upload = _WebHostEnvironment.WebRootPath + WC.ImagePath;
                var oldFile = Path.Combine(upload, obj.image);
                if (System.IO.File.Exists(oldFile))
                {
                    System.IO.File.Delete(oldFile);
                }
                _pdB.Products.Remove(obj);
                _pdB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
