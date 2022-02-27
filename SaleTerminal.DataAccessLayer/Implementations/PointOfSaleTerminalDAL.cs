using SaleTerminal.BusinessEntities;
using SaleTerminal.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SaleTerminal.DataAccessLayer.Implementations
{
    public class PointOfSaleTerminalDAL : IPointOfSaleTerminalDAL
    {
        private static List<ProductDetails> ProductDetailsList = new List<ProductDetails>();
        public void DeleteProduct(string productCode)
        {
            ProductDetailsList.RemoveAll(x => x.ProductCode.Trim().ToLower() == productCode.Trim().ToLower());
        }

        public void SetPricing(List<ProductDetails> prodDetailsList)
        {
            foreach (var productDetails in prodDetailsList)
            {
                if (ProductDetailsList.Any(x => x.ProductCode.Trim().ToLower() == productDetails.ProductCode.Trim().ToLower()))
                {
                    var item = ProductDetailsList.FirstOrDefault(x => x.ProductCode.Trim().ToLower() == productDetails.ProductCode.Trim().ToLower());
                    item.UnitPrice = productDetails.UnitPrice;
                    item.PriceDetailsList = productDetails.PriceDetailsList;
                }
                else
                {
                    ProductDetailsList.Add(productDetails);
                }
            }
        }

        public ProductDetails GetProductDetailsBasedOnProductCode(string productCode)
        {
            return ProductDetailsList.FirstOrDefault(x => x.ProductCode.Trim().ToLower() == productCode.Trim().ToLower());
        }
    }
}
