using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BProduct
    {
        public List<Product> GetAllProducts()
        {
            DProduct dataProduct = new DProduct();
            List<Product> allProducts = dataProduct.GetAllP();
            return allProducts;
        }
        public void InsertProduct(Product product)
        {
            DProduct dataProduct = new DProduct();
            dataProduct.InsertProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            DProduct dataProduct = new DProduct();
            dataProduct.UpdateProduct(product);
        }

        public void DeleteProduct(int productId)
        {
            DProduct dataProduct = new DProduct();
            dataProduct.SoftDeleteProduct(productId);
        }
    }
}
