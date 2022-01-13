using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace billing.Data.EntitiyConfigurations
{

    public class MstCustomerConfigurations : IEntityTypeConfiguration<MstCustomer>
    {
        public void Configure(EntityTypeBuilder<MstCustomer> builder)
        {
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(x => x.ModifiedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(a => a.Name).HasMaxLength(300);
            builder.Property(a => a.UId).IsRequired();
            builder.Property(a => a.VehicleNumber).IsRequired();
            builder.Property(a => a.PhoneNumber).IsRequired().HasMaxLength(12);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
