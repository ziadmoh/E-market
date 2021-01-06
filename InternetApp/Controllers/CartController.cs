using System;
using System.Collections.Generic;
using System.Linq;
using InternetApp.Context;
using System.Web;
using System.Web.Mvc;
using InternetApp.ViewModel;
using InternetApp.Models;
using System.Data.Entity;
namespace InternetApp.Controllers
{
    public class CartController : Controller
    {
        private ProductCategory db = new ProductCategory();
        // GET: Cart
        public ActionResult Index()
        {
            List<Cart> Cart = db.Cart.Include(a => a.product).ToList();
            return PartialView("_ShowCart", Cart);
        }

        [HttpPost]
        public void addtocart(int Productid)
        {
            var Product = db.Product.SingleOrDefault(c => c.id == Productid);
            var Cart = new Cart();

            ProductCart pc = new ProductCart()
            {
                Product = Product,
                Cart = Cart

            };
            pc.Cart.added_at = DateTime.Now;

            pc.Cart.product_id = pc.Product.id;
            db.Cart.Add(pc.Cart);
            db.SaveChanges();
  
        }

        [HttpPost]
        public void DeleteCart(int id)
        {
            var Cart = db.Cart.Single(c => c.product_id == id);
            db.Cart.Remove(Cart);
            db.SaveChanges();
          
        }
    }
}