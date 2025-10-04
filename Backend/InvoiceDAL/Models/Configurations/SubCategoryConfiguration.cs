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
    internal class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.ConcurrencyStamp).IsRequired();
            builder.Property(sc => sc.Name).IsRequired().HasMaxLength(100);
            builder.HasIndex(sc => sc.Name).IsUnique();
            builder.HasData(SeedData.GetSubCategories());
        }
    }
}
