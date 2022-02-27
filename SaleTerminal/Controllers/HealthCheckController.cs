using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaleTerminal.BusinessEntities.Constants;
using System.Diagnostics.CodeAnalysis;

namespace SaleTerminal.Controllers
{
    [AllowAnonymous]
    [ExcludeFromCodeCoverage]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// Health check API
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(RouteConstants.HealthCheck)]
        public string HealthCheck()
        {
            return "Hello From Health Check Method";
        }
    }
}
