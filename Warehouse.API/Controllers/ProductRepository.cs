using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain;

namespace Warehouse.API.Controllers
{
    public static class ProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public static int Add(Product product)
        {
            _products.Add(product);

            return product.Id;
        }

        public static Product? Get(int productId)
        {
            return _products.FirstOrDefault(x => x.Id == productId);
        }

        public static bool Update(Product updatedProduct)
        {
            var products = _products.FirstOrDefault(x => x.Id == updatedProduct.Id);

            if (products == null)
            {
                return false;
            }

            _products.Remove(products);

            _products.Add(updatedProduct);

            return true;
        }
    }
}
