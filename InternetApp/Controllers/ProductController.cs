using InternetApp.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InternetApp.ViewModel;
using InternetApp.Models;
using System.Web.UI.WebControls;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;

namespace InternetApp.Controllers
{
    public class ProductController : Controller
    {
        private ProductCategory db = new ProductCategory();
        // GET: Product
        
        public ActionResult Index()
        {
            List<Product> products = db.Product.Include(a =>a.Category).ToList();
            return View(products);
        }
        [HttpPost]
        public ActionResult Index(String name)
        {
            List<Product> products;
            if (String.IsNullOrEmpty(name))
            {
                products = db.Product.Include(c => c.Category).ToList();
            }
            else
            {
                products = db.Product.Include(c => c.Category).Where(c => c.Category.name.Contains(name) || name == null).ToList();
            }
            return View(products);
        }
        [HttpGet]
        public ActionResult New()
        {
            var Category = db.Category.ToList();
            ProductCategoryModel pc = new ProductCategoryModel()
            {
                Category = Category
            };
            return View(pc);
        }
        [HttpPost]
        public ActionResult New(ProductCategoryModel pc)
        {


          
            if (ModelState.IsValid)
            {
                if (pc.file != null)
                {
                    String img = System.IO.Path.GetFileName(pc.file.FileName);
                    String path = System.IO.Path.Combine(Server.MapPath("~/images/Products/"), img);
                    pc.file.SaveAs(path);
                    pc.Product.image = img;
                }

                db.Product.Add(pc.Product);
                db.SaveChanges();
                var categories = db.Category.SingleOrDefault(c => c.id == pc.Product.CategoryId);
                categories.number_of_products++;
                db.Entry(categories).State = EntityState.Modified;
                db.SaveChanges();
               


            }
            return RedirectToAction("Index");



        }
        public ActionResult Edit(int id)
        {
            var Product = db.Product.SingleOrDefault(c => c.id == id);
            if (Product == null)
            {
                return HttpNotFound();
            }
            var Category = db.Category.ToList();
            ProductCategoryModel pc = new ProductCategoryModel()
            {
                Category = Category,
                Product = Product
            };
            return View(pc);
        }

        [HttpPost]
        public ActionResult Edit(ProductCategoryModel pc)
        {
            if (!ModelState.IsValid)
            {
                var Category = db.Category.ToList();
                pc.Category = Category;
                return View("Edit", pc);

            }
            var Product = db.Product.SingleOrDefault(c => c.id == pc.Product.id);
            Product.name = pc.Product.name;
           
            Product.price = pc.Product.price;
            Product.CategoryId = pc.Product.CategoryId;
            Product.description = pc.Product.description;
            if (pc.file != null)
            {
                String img = System.IO.Path.GetFileName(pc.file.FileName);
                String path = System.IO.Path.Combine(Server.MapPath("~/images/Products/"), img);
                pc.file.SaveAs(path);
                Product.image = img;
            }
            
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details",new {id=pc.Product.id });
        }
    

     
    

        public ActionResult Delete(int id)
        {
            var Product = db.Product.Single(c => c.id == id);
           
            
            if (Product != null)
            {
                var p = db.Category.SingleOrDefault(c => c.id == Product.CategoryId);
                p.number_of_products--;
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                db.Product.Remove(Product);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var Product = db.Product.Single(c => c.id == id);
            var Category = db.Category.ToList();
            ProductCategoryModel pc = new ProductCategoryModel()
            {
                Category = Category,
                Product = Product
            };
            return View(pc);
        }
        [HttpPost]
        public ActionResult Details(ProductCategoryModel pc)
        {

            var Product = db.Product.Single(c => c.id == pc.Product.id);
            return View("Details", Product);
        }
        public ActionResult Search(String name)
        {
            List<Product> Product = db.Product.Include(c => c.Category).Where(c => c.Category.name.Contains(name) || name == null).ToList();

            return View(Product);
        }
        public JsonResult GetCategoryName(string term)
        {
            List<string> AllCategories;

            AllCategories = db.Product.Where(a => a.Category.name.ToLower().StartsWith(term.ToLower())).Select(v => v.Category.name).ToList();

            return Json(AllCategories, JsonRequestBehavior.AllowGet);
        }


    }
}