using InvoiceDAL.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models.Configurations
{
    internal class ItemsConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Description).HasMaxLength(150);
            builder.Property(x=>x.Unit).IsRequired().HasMaxLength(20);
            builder.Property(x => x.CurrentPrice).IsRequired().HasPrecision(18, 2);
            builder.Property(x=>x.Quantity).IsRequired().HasPrecision(18, 2).HasDefaultValue(1);
            //builder.HasData(SeedData.GetItems());
        }
    }
}
