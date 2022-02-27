using System.Collections.Generic;

namespace SaleTerminal.BusinessEntities
{
    public class ProductDetails
    {
        public string ProductCode { get; set; }
        public decimal UnitPrice { get; set; }
        public List<PriceDetails> PriceDetailsList { get; set; }
    }

    public class PriceDetails
    {
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
