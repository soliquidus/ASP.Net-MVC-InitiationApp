using System.Collections.Generic;
using System.Linq;
using Company.DataLayer;
using Company.DomainModels;
using Company.ServiceContracts;

namespace Company.ServiceLayer
{
    public class ProductService: IProductsService
    {
        private readonly CompanyDbContext _db = new CompanyDbContext();

        public List<Product> GetProducts()
        {
            var products = _db.Products.ToList();
            return products;
        }

        public List<Product> SearchProducts(string productName)
        {
            var products = _db.Products.Where(p => p.ProductName.Contains(productName)).ToList();
            return products;
        }

        public Product GetProductByProductId(long productId)
        {
            var product = _db.Products.FirstOrDefault(p => p.ProductID == productId);
            return product;
        }

        public void InsertProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _db.Products.FirstOrDefault(temp => temp.ProductID == product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Price = product.Price;
                existingProduct.Dop = product.Dop;
                existingProduct.CategoryID = product.CategoryID;
                existingProduct.BrandID = product.BrandID;
                existingProduct.AvailabilityStatus = product.AvailabilityStatus;
                existingProduct.Active = product.Active;
                existingProduct.Photo = product.Photo;
            }

            _db.SaveChanges();
        }

        public void DeleteProduct(long productId)
        {
            var existingProduct = _db.Products.FirstOrDefault(temp => temp.ProductID == productId);
            if (existingProduct != null) _db.Products.Remove(existingProduct);
            _db.SaveChanges();
        }
    }
}