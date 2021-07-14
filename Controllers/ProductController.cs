using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Data.Entity;
using WebApplication2.viewmodel;
using System.IO;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]

        public ActionResult Index()
        {
            var products = db.products.Include(u => u.category).ToList();

            return View(products);
        }


        [HttpPost]
        public ActionResult Index(string search)
        {


            List<Product> products;
            if (string.IsNullOrEmpty(search))

            {
                products = db.products.Include(u => u.category).ToList();


            }

            else

            {
                products = db.products.Include(u => u.category).Where(a => a.category.name.StartsWith(search)).ToList();


            }
            return View(products);
        }










        public ActionResult Details(int id)
        {

            var product = db.products.Single(c => c.id == id);

            if (product == null)
            { return HttpNotFound(); }

            return View(product);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var categories = db.categories.ToList();

            CategoryProduct cp = new CategoryProduct
            {
                categories = categories
            };

            return View(cp);
        }

        [HttpPost]
        public ActionResult Create(CategoryProduct cp, HttpPostedFileBase Upload)
        {

            if (Upload != null)
            {
                string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
                Upload.SaveAs(path);
                cp.Product.image = Upload.FileName;
            }
            db.products.Add(cp.Product);
            db.SaveChanges();

            var category = db.categories.SingleOrDefault(u => u.id == cp.Product.Category_id);
            category.number_of_products++;
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
                  return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {   
            var product = db.products.SingleOrDefault(c => c.id == id);
            var categories = db.categories.ToList();
            if (product == null)
            {
                return HttpNotFound();
            }
            CategoryProduct cp = new CategoryProduct
            {
                categories = categories,
                Product = product
            };

            return View(cp);
        }


        [HttpPost]
        public ActionResult Edit(CategoryProduct cp, HttpPostedFileBase Upload)
        { var productsdb = db.products.SingleOrDefault(c => c.id == cp.Product.id);

                productsdb.name = cp.Product.name;
                productsdb.price = cp.Product.price;
                productsdb.description = cp.Product.description;
                productsdb.Category_id = cp.Product.Category_id;
                if (Upload != null)
                {
                    string path = Path.Combine(Server.MapPath("~/Uploads"), Upload.FileName);
                    Upload.SaveAs(path);
                    productsdb.image = Upload.FileName;
                    
                }
                db.Entry(productsdb).State = EntityState.Modified;
                db.SaveChanges();
              
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.products.Single(c => c.id == id);
            db.products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



    }

}

   