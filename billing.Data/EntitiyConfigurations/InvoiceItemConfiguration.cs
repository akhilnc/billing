using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace billing.Data.EntitiyConfigurations
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.Property(a => a.Amount).IsRequired().HasMaxLength(10);
            builder.Property(a => a.InvoiceId).IsRequired().HasMaxLength(50);
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.HasOne(e => e.Invoice)
                    .WithMany(e => e.InvoiceItems)
                    .HasForeignKey(e => e.InvoiceId);
              
        }
    }
}
