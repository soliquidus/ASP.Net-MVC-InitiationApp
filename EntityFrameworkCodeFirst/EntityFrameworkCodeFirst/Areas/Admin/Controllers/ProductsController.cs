using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Company.DataLayer;
using EntityFrameworkCodeFirst.Filters;
using Company.DomainModels;
using Company.ServiceContracts;
using Company.ServiceLayer;

namespace EntityFrameworkCodeFirst.Areas.Admin.Controllers
{
    [AdminAuthorization]
    public class ProductsController : Controller
    {
        private readonly CompanyDbContext _db = new CompanyDbContext();
        private IProductsService _productsService = new ProductService();
        
        public ActionResult Index(string search = "", string sortColumn = "ProductName", string iconClass = "fa-sort-asc", int pageNo = 1)
        {
            ViewBag.search = search;
            List<Product> products = _productsService.SearchProducts(search);

            /*Sorting*/
            ViewBag.SortColumn = sortColumn;
            ViewBag.IconClass = iconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.ProductID).ToList() : products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if (ViewBag.SortColumn == "ProductName")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.ProductName).ToList() : products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.Price).ToList() : products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.Dop).ToList() : products.OrderByDescending(temp => temp.Dop).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.AvailabilityStatus).ToList() : products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.Category.CategoryName).ToList() : products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                products = ViewBag.IconClass == "fa-sort-asc" ? products.OrderBy(temp => temp.Brand.BrandName).ToList() : products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
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
            Product p = _productsService.GetProductByProductId(id);
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
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID, ProductName, Price, Dop, AvailabilityStatus, CategoryID, BrandID, Active, Photo")] Product p)

        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }

                _productsService.InsertProduct(p);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _db.Categories.ToList();
                ViewBag.Brands = _db.Brands.ToList();
                return View();
            }
        }

        // Update
        public ActionResult Edit(long id)
        {
            Product existingProduct = _productsService.GetProductByProductId(id);
            ViewBag.Categories = _db.Categories.ToList();
            ViewBag.Brands = _db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                Product existingProduct = _productsService.GetProductByProductId(p.ProductID);
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    if (existingProduct != null) existingProduct.Photo = base64String;
                }

                if (existingProduct != null)
                {
                    existingProduct.ProductName = p.ProductName;
                    existingProduct.Price = p.Price;
                    existingProduct.Dop = p.Dop;
                    existingProduct.CategoryID = p.CategoryID;
                    existingProduct.BrandID = p.BrandID;
                    existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                    existingProduct.Active = p.Active;
                }

                _productsService.UpdateProduct(p);
            }

            return RedirectToAction("Index", "Products");
        }

        // Delete
        public ActionResult Delete(long id)
        {
            Product existingProduct = _productsService.GetProductByProductId(id);
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product p)
        {
            _productsService.DeleteProduct(id);
            return RedirectToAction("Index", "Products");
        }
    }
}