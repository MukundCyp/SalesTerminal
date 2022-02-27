namespace SaleTerminal.BusinessEntities.Constants
{
    /// <summary>
    /// Maintain Routing path for the API's
    /// </summary>
    public static class RouteConstants
    {
        /// <summary>
        /// Health check
        /// </summary>
        public const string HealthCheck = "~/api/HealthCheck";

        /// <summary>
        /// Calculate Total Price
        /// </summary>
        public const string CalculateTotal = "~/api/CalculateTotal";

        /// <summary>
        /// Set Product Price
        /// </summary>
        public const string SetProductPrice = "~/api/SetProductPrice";

        /// <summary>
        /// Delete Product Details
        /// </summary>
        public const string DeleteProductDetails = "~/api/DeleteProductDetails";
    }
}
