using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class CoffeShopConfiguration : IEntityTypeConfiguration<CoffeShop>
    {
        public void Configure(EntityTypeBuilder<CoffeShop> builder)
        {
            builder.Property(c => c.Address).HasMaxLength(200);
            builder.Property(c => c.Name).HasMaxLength(200);
            builder.Property(c => c.OpeningHours).HasMaxLength(200);
        }
    }
}
