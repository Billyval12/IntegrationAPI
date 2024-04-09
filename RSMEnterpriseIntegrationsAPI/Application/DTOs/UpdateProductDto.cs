namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class UpdateProductDto
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ProductNumber { get; set; } = string.Empty;
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public int SafetyStockLevel { get; set; }
        public int ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime SellStartDate { get; set; }
    }
}
