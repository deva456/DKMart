

using DKMart.Data;
using DKMart.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DKMart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DKSuperMarketDbContext _db;
        public CategoryController(DKSuperMarketDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category;
            return View(objList);
        }

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            
                return View(obj);
            
        }

        //GET - Edit
        public IActionResult Edit(int? CatId)
        {
            if (CatId == null|| CatId==0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(CatId);
            if (obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        //GET - Delete
        public IActionResult Delete(int? CatId)
        {
            if (CatId == null || CatId == 0)
            {
                return NotFound();
            }
            var obj = _db.Category.Find(CatId);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? CatId)
        {

            if (CatId == null || CatId == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(CatId);
            if (obj!=null)
            {
                _db.Category.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
    }
}
