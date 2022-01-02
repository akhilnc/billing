using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace billing.Data.EntitiyConfigurations
{
   public  class MstServiceConfiguration :IEntityTypeConfiguration<MstService>
    {
        public void Configure(EntityTypeBuilder<MstService> builder)
        {

            builder.Property(x => x.CreatedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(x => x.ModifiedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(300);
            builder.Property(a => a.UId).IsRequired();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
