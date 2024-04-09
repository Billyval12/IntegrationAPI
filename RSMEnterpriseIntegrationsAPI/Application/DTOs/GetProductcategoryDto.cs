namespace RSMEnterpriseIntegrationsAPI.Application.DTOs
{
    public class GetProductCategoryDto
    {
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public Guid Rowguid { get; set; }
    }
}
