using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RSMEnterpriseIntegrationsAPI.Domain.Models;

namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product), "Production");

            builder.HasKey(e => e.ProductID);
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.ProductNumber).IsRequired();
            builder.Property(e => e.MakeFlag).IsRequired();
            builder.Property(e => e.FinishedGoodsFlag).IsRequired();
            builder.Property(e => e.SafetyStockLevel).IsRequired();
            builder.Property(e => e.ReorderPoint).IsRequired();
            builder.Property(e => e.StandardCost).IsRequired();
            builder.Property(e => e.ListPrice).IsRequired();
            builder.Property(e => e.SellStartDate).IsRequired();
        }
    }
}
