using InternetApp.Context;
using InternetApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetApp.Controllers
{
    public class CategoryController : Controller
    {
        private ProductCategory db = new ProductCategory();
        // GET: Category
        public ActionResult Index()
        {
            var category = db.Category.ToList();
            return View(category);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            
            var p = db.Category.SingleOrDefault(c => c.id == id);

                    db.Category.Remove(p);
                    db.SaveChanges();
               
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var Category = db.Category.SingleOrDefault(c => c.id == id);
           
            return View(Category);
        }
        [HttpPost]
        public ActionResult Edit(Category Category)
        {
            if (ModelState.IsValid)
            {

                var Categor = db.Category.SingleOrDefault(c => c.id == Category.id);
                Categor.name = Category.name;
                db.Entry(Categor).State = EntityState.Modified;
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

    }
}