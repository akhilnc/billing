
using billing.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace billing.Data.EntitiyConfigurations
{

    public class MstUserRoleConfiguration : IEntityTypeConfiguration<MstUserRole>
    {
        public void Configure(EntityTypeBuilder<MstUserRole> builder)
        {
            builder.HasData(new MstUserRole
            {
                Id = 1,
                UId = Guid.NewGuid().ToString(),
                CreatedBy = "test",
                CreatedOn = DateTime.Now,
                IsActive = true,
                ModifiedBy = "asda",
                ModifiedOn = DateTime.Now,
                Name = "admin",
                ShortName = "Ad"
            }
            );
        }
    }

}
