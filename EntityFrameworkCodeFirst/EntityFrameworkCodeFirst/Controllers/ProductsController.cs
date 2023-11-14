﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CompanyDbContext _db = new CompanyDbContext();
        public ActionResult Index(string search = "", string sortColumn = "ProductName", string iconClass = "fa-sort-asc", int pageNo = 1)
        {
            ViewBag.search = search;
            List<Product> products = _db.Products.Where(temp => temp.ProductName.Contains(search)).Include(product => product.Category).Include(product1 => product1.Brand).ToList();
            
            /*Sorting*/
            ViewBag.SortColumn = sortColumn;
            ViewBag.IconClass = iconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.ProductID).ToList() : 
                    products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.ProductName).ToList() : 
                    products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.Price).ToList() : 
                    products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.Dop).ToList() : 
                    products.OrderByDescending(temp => temp.Dop).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.AvailabilityStatus).ToList() : 
                    products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.Category.CategoryName).ToList() : 
                    products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? 
                    products.OrderBy(temp => temp.Brand.BrandName).ToList() :
                    products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }
            
            /* Paging */
            int noOfProductsPerPage = 5;
            int noOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(noOfProductsPerPage)));
            int noOfProductsToSkip = (pageNo - 1) * noOfProductsPerPage;
            ViewBag.PageNo = pageNo;
            ViewBag.NoOfPages = noOfPages;
            products = products.Skip(noOfProductsToSkip).Take(noOfProductsPerPage).ToList();

            return View(products);
        }
        
        // Read
        public ActionResult Details(long id)
        {
            Product p = _db.Products.FirstOrDefault(temp => temp.ProductID == id);
            return View(p);
        }
        
        
        // Create
        public ActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            ViewBag.Brands = _db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (Request.Files.Count >= 1)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file != null)
                {
                    byte[] imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }
            }
            _db.Products.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // Update
        public ActionResult Edit(long id)
        {
            Product existingProduct = _db.Products.FirstOrDefault(temp => temp.ProductID == id);
            ViewBag.Categories = _db.Categories.ToList();
            ViewBag.Brands = _db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            Product existingProduct = _db.Products.FirstOrDefault(temp => temp.ProductID == p.ProductID);
            existingProduct.ProductName = p.ProductName;
            existingProduct.Price = p.Price;
            existingProduct.Dop = p.Dop;
            existingProduct.CategoryID = p.CategoryID;
            existingProduct.BrandID = p.BrandID;
            existingProduct.AvailabilityStatus = p.AvailabilityStatus;
            existingProduct.Active = p.Active;
            _db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
        
        // Delete
        public ActionResult Delete(long id)
        {
            Product existingProduct = _db.Products.FirstOrDefault(temp => temp.ProductID == id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            Product existingProduct = _db.Products.FirstOrDefault(temp => temp.ProductID == id);
            _db.Products.Remove(existingProduct);
            _db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}