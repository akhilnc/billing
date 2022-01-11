using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.EntitiyConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {

            builder.Property(x => x.CreatedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);
            builder.Property(x => x.ModifiedOn).HasDefaultValueSql(ApplicationConstants.CurrentDateDefaultValueSql);     
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.InvoiceNo).IsRequired().HasMaxLength(50);
            builder.Property(a => a.SubTotal).IsRequired().HasMaxLength(10);
            builder.Property(a => a.TotalAmount).IsRequired().HasMaxLength(10);
            builder.Property(a => a.CustomerId).IsRequired();
            builder.Property(a => a.Discount).IsRequired();
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(e => e.Customer)
                .WithOne(e => e.Invoice)
                .HasForeignKey<Invoice>(p => p.CustomerId);
        }
    }
}
