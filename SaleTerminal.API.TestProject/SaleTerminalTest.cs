using Newtonsoft.Json;
using SaleTerminal.BusinessEntities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SaleTerminal.API.TestProject
{
    public class SaleTerminalTest
    {
        [Fact]
        public async Task SetPriceDetailsObj_Test()
        {
            List<ProductDetails> productDetailsList = new List<ProductDetails>();
            ProductDetails priceDetails1 = new ProductDetails()
            {
                ProductCode = "A",
                UnitPrice = (decimal)1.25,
                PriceDetailsList = new List<PriceDetails>()
                { new PriceDetails() { Price = 3, Quantity = 3},
                    new PriceDetails() { Price = (decimal)4.5, Quantity = 5 } }
            };
            ProductDetails priceDetails2 = new ProductDetails()
            {
                ProductCode = "B",
                UnitPrice = (decimal)4.25
            };
            ProductDetails priceDetails3 = new ProductDetails()
            {
                ProductCode = "C",
                UnitPrice = (decimal)1,
                PriceDetailsList = new List<PriceDetails>()
                { new PriceDetails() { Price = 5, Quantity = 6} }
            };
            ProductDetails priceDetails4 = new ProductDetails()
            {
                ProductCode = "D",
                UnitPrice = (decimal)0.75
            };
            ProductDetails priceDetails5 = new ProductDetails()
            {
                ProductCode = "E",
                UnitPrice = (decimal)0.75
            };
            productDetailsList.Add(priceDetails1);
            productDetailsList.Add(priceDetails2);
            productDetailsList.Add(priceDetails3);
            productDetailsList.Add(priceDetails4);
            productDetailsList.Add(priceDetails5);
            var client = new TestClientProvider().Client;
            var data = new StringContent(JsonConvert.SerializeObject(productDetailsList), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/SetProductPrice", data);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task DeleteProductDetails_Test()
        {
            var client = new TestClientProvider().Client;
            await SetPriceDetailsObj_Test();
            var response = await client.PostAsync("/api/DeleteProductDetails?productCode=E", null);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CalculateTotal_Test1()
        {
            var client = new TestClientProvider().Client;
            await SetPriceDetailsObj_Test();
            var response = await client.GetAsync("/api/CalculateTotal?products=ABCDABA");
            Assert.True(response.StatusCode == HttpStatusCode.OK && response.Content.ReadAsStringAsync().Result == "13.25");
        }
        [Fact]
        public async Task CalculateTotal_Test2()
        {
            var client = new TestClientProvider().Client;
            await SetPriceDetailsObj_Test();
            var response = await client.GetAsync("/api/CalculateTotal?products=CCCCCCC");
            Assert.True(response.StatusCode == HttpStatusCode.OK && response.Content.ReadAsStringAsync().Result == "6.0");
        }
        [Fact]
        public async Task CalculateTotal_Test3()
        {
            var client = new TestClientProvider().Client;
            await SetPriceDetailsObj_Test();
            var response = await client.GetAsync("/api/CalculateTotal?products=ABCD");
            Assert.True(response.StatusCode == HttpStatusCode.OK && response.Content.ReadAsStringAsync().Result == "7.25");
        }
        [Fact]
        public async Task CalculateTotal_Test4()
        {
            var client = new TestClientProvider().Client;
            await SetPriceDetailsObj_Test();
            var response = await client.GetAsync("/api/CalculateTotal?products=ABCDAAAAA");
            Assert.True(response.StatusCode == HttpStatusCode.OK && response.Content.ReadAsStringAsync().Result == "11.75");
        }
    }
}
