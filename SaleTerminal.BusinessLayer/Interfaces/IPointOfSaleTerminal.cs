using SaleTerminal.BusinessEntities;
using System.Collections.Generic;

namespace SaleTerminal.BusinessLayer.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        public void SetPricing(List<ProductDetails> prodDetailsList);
        public ProductDetails ScanProduct(string productCode);
        public decimal CalculateTotal(string allProductCodes);
        public void DeleteProduct(string productCode);
    }
}
