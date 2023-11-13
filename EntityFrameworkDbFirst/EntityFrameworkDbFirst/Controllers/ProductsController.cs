using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EntityFrameworkDbFirst.Models;

namespace EntityFrameworkDbFirst.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(string search = "")
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            ViewBag.search = search;
            List<Product> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();
            return View(products);
        }
        
        // Read
        public ActionResult Details(long id)
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            Product p = db.Products.FirstOrDefault(temp => temp.ProductID == id);
            return View(p);
        }
        
        
        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // Update
        public ActionResult Edit(long id)
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            Product existingProduct = db.Products.FirstOrDefault(temp => temp.ProductID == id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            Product existingProduct = db.Products.FirstOrDefault(temp => temp.ProductID == p.ProductID);
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.DateOfPurchase = p.DateOfPurchase;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        
        // Delete
        public ActionResult Delete(long id)
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            Product existingProduct = db.Products.FirstOrDefault(temp => temp.ProductID == id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            EntityFrameworkDbFirstDBEntities db = new EntityFrameworkDbFirstDBEntities();
            Product existingProduct = db.Products.FirstOrDefault(temp => temp.ProductID == id);
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}