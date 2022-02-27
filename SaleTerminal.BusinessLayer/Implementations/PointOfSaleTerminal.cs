using SaleTerminal.BusinessEntities;
using SaleTerminal.BusinessLayer.Interfaces;
using SaleTerminal.DataAccessLayer.Interfaces;
using System.Collections.Generic;

namespace SaleTerminal.BusinessLayer.Implementations
{
    public class PointOfSaleTerminal : IPointOfSaleTerminal
    {
        private readonly IPointOfSaleTerminalDAL _pointOfSaleTerminalDAL;
        public PointOfSaleTerminal(IPointOfSaleTerminalDAL pointOfSaleTerminalDAL)
        {
            _pointOfSaleTerminalDAL = pointOfSaleTerminalDAL;
        }

        public decimal CalculateTotal(string allProductCodes)
        {
            allProductCodes = allProductCodes.Replace(" ","").ToLower();
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            foreach(char str in allProductCodes.ToCharArray())
            {
                if (keyValuePairs.ContainsKey(str.ToString()))
                {
                    keyValuePairs[str.ToString()]++;
                }
                else
                {
                    keyValuePairs.Add(str.ToString(), 1);
                }
            }
            decimal totalPrice = 0;
            foreach(var item in keyValuePairs)
            {
                ProductDetails prodDetails = ScanProduct(item.Key);
                List<decimal> remPriceList = new List<decimal>();
                List<decimal> mulPriceList = new List<decimal>();
                if (prodDetails != null)
                {
                    decimal unitPrice = prodDetails.UnitPrice;
                    decimal temp = 0;
                    if (prodDetails.PriceDetailsList != null && prodDetails.PriceDetailsList.Count > 0)
                    {
                        prodDetails.PriceDetailsList.ForEach(x =>
                        {
                            remPriceList.Add(unitPrice * (item.Value % x.Quantity));
                            mulPriceList.Add(x.Price * (item.Value / x.Quantity));
                        });
                        for (int i = 0; i < remPriceList.Count; i++)
                        {
                            decimal temp1 = remPriceList[i] + mulPriceList[i];
                            if (temp1 < temp || i == 0)
                                temp = temp1;
                        }
                    }
                    else
                    {
                        temp = unitPrice * item.Value;
                    }
                    totalPrice += temp;
                }
            }
            return totalPrice;
        }

        public void DeleteProduct(string productCode)
        {
            _pointOfSaleTerminalDAL.DeleteProduct(productCode);
        }

        public ProductDetails ScanProduct(string productCode)
        {
            return _pointOfSaleTerminalDAL.GetProductDetailsBasedOnProductCode(productCode);
        }

        public void SetPricing(List<ProductDetails> prodDetailsList)
        {
            _pointOfSaleTerminalDAL.SetPricing(prodDetailsList);
        }
    }
}
