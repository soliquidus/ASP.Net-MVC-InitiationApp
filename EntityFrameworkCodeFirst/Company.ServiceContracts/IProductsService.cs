using System.Collections.Generic;
using Company.DomainModels;

namespace Company.ServiceContracts
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        List<Product> SearchProducts(string productName);
        Product GetProductByProductId(long productId);
        void InsertProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(long productId);
    }
}