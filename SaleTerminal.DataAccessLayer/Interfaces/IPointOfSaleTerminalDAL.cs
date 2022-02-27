using SaleTerminal.BusinessEntities;
using System.Collections.Generic;

namespace SaleTerminal.DataAccessLayer.Interfaces
{
    public interface IPointOfSaleTerminalDAL
    {
        public void SetPricing(List<ProductDetails> prodDetailsList);
        public void DeleteProduct(string productCode);
        public ProductDetails GetProductDetailsBasedOnProductCode(string productCode);
    }
}
