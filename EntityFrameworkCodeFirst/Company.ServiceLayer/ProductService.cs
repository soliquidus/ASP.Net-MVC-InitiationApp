using System;
using System.Collections.Generic;
using Company.DomainModels;
using Company.RepositoryContracts;
using Company.ServiceContracts;

namespace Company.ServiceLayer
{
    public class ProductService: IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetProducts()
        {
            var products = _productsRepository.GetProducts();
            return products;
        }

        public List<Product> SearchProducts(string productName)
        {
            var products = _productsRepository.SearchProducts(productName);
            return products;
        }

        public Product GetProductByProductId(long productId)
        {
            var product = _productsRepository.GetProductByProductId(productId);
            return product;
        }

        public void InsertProduct(Product product)
        {
            if (product.Price <= 100000)
            {
                _productsRepository.InsertProduct(product);    
            }
            else
            {
                throw new Exception("Price exceeds limit");
            }
        }

        public void UpdateProduct(Product product)
        {
            _productsRepository.UpdateProduct(product);
        }

        public void DeleteProduct(long productId)
        {
            _productsRepository.DeleteProduct(productId);
        }
    }
}