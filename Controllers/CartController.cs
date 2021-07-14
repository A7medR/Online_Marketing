using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart

        public ActionResult Index()
        {
            var products = db.products.Include(u => u.category).ToList();

            return View(products);
        }
        public ActionResult viewCart()
        {
            var products = db.carts.ToList();

            return PartialView("~/Views/Cart/_viewCart.cshtml",products);
        }


        public ActionResult AddToCart(int id)
        {
            //retrieve the product from database
            var addproduct = db.products.Single(product => product.id == id);
            //add it to shopping cart 
            Cart cart = new Cart
            {
                product_id = id,
                Product = db.products.SingleOrDefault(p => p.id == id),
                added_at = DateTime.Now,
            };

            db.carts.Add(cart);
            db.SaveChanges();
            DateTime newdate = DateTime.Now;
            TimeSpan ts = newdate - cart.added_at;
            db.Entry(cart).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


        public ActionResult RemoveLine(int id)
        {
            var removeproduct = db.carts.Single(Cart=> Cart.product_id == id);
            db.carts.Remove(removeproduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

    }


}
