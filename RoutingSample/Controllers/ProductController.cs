using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoutingSample.Models;

namespace RoutingSample.Controllers
{
    public class ProductController : Controller
    {
        private RoutingSampleContext db = new RoutingSampleContext();

        //
        // GET: /Products/

        //public ActionResult Index()
        //{
        //    return View(db.Products.ToList());
        //}

        //
        // GET: /Products/

        public ActionResult Index(string category, string name)
        {
            int cat = String.IsNullOrEmpty(category) ? 0 : 2;
            int nam = String.IsNullOrEmpty(name) ? 0 : 1;
            int val = cat | nam;
            switch (val)
            {
                case 0: 
                // This is for the base route .../Product/Index/ or .../Product/
                    return View(db.Products.ToList());
                case 2: 
                // This is for only category .../Product/Index/Electronics
                    return View((from product in db.Products
                             where product.Category == category
                             select product).ToList<Product>());
                case 1:
                // This case is reachable only via .../Product/Index?name=Asus
                    return View((from product in db.Products
                                 where product.ProductName == name
                                 select product).ToList<Product>());
                case 3:
                // This case is reachable .../Product/Electronics/Sony
                    return View((from product in db.Products
                                 where product.Category == category &&
                                 product.ProductName == name
                                 select product).ToList<Product>());
                default:
                    return View();
            }
        }

        //
        // GET: /Products/Details/5

        public ActionResult Details(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // GET: /Products/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Products/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //
        // GET: /Products/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Products/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /Products/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}