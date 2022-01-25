using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.EntitiyConfigurations
{
    public class CompanySettingsConfiguration : IEntityTypeConfiguration<CompanySettings>
    {
        public void Configure(EntityTypeBuilder<CompanySettings> builder)
        {
            builder.Property(x => x.CreatedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(x => x.ModifiedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Logo).IsRequired().HasMaxLength(50);
            builder.Property(a => a.PhoneNo).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Address1).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Address2).IsRequired().HasMaxLength(100);
            builder.Property(a => a.District).IsRequired().HasMaxLength(50);
            builder.Property(a => a.State).IsRequired().HasMaxLength(10);
            builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Email).IsRequired().HasMaxLength(50);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
