using Microsoft.AspNetCore.Mvc;
using SaleTerminal.BusinessEntities;
using SaleTerminal.BusinessEntities.Constants;
using SaleTerminal.BusinessLayer.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace SaleTerminal.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    public class PointOfSaleTerminalController : ControllerBase
    {
        private readonly IPointOfSaleTerminal _pointOfSaleTerminal;
        public PointOfSaleTerminalController(IPointOfSaleTerminal pointOfSaleTerminal)
        {
            _pointOfSaleTerminal = pointOfSaleTerminal;
        }

        [HttpGet]
        [Route(RouteConstants.CalculateTotal)]
        public ActionResult CalculateTotal(string products)
        {
            try
            {
                return Ok(_pointOfSaleTerminal.CalculateTotal(products));
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route(RouteConstants.SetProductPrice)]
        public ActionResult SetProductPrice(List<ProductDetails> prodDetailsList)
        {
            try
            {
                _pointOfSaleTerminal.SetPricing(prodDetailsList);
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        [HttpPost]
        [Route(RouteConstants.DeleteProductDetails)]
        public ActionResult DeleteProductDetails(string productCode)
        {
            try
            {
                _pointOfSaleTerminal.DeleteProduct(productCode);
                return Ok(true);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
