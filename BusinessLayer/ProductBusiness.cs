using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductBusiness
    {
        private readonly ProductRepository productRepository = new ProductRepository();

        public List<Product> GetProducts()
        {
            return productRepository.GetAllProducts().Where(product => DateTime.Now < product.ExpireyDate).ToList();
        }

        public bool InsertProduct(Product product)
        {
            return productRepository.InsertProduct(product) != 0;
        }
    }
}