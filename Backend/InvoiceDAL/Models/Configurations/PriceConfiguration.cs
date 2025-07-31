using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models.Configurations
{
    internal class PriceConfiguration : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            builder.HasKey(x => new { x.ItemId, x.CreatedOn });
            builder.Property(x=>x.Value).IsRequired().HasPrecision(18,2);
            builder.Property(x=>x.ItemId).IsRequired();
            builder.Property(x => x.CreatedOn).IsRequired();
        }
    }
}
