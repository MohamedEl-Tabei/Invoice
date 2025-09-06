using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models.Configurations
{
    internal class ItemsRelationships : IEntityTypeConfiguration<Item>, IEntityTypeConfiguration<UserApp>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            //builder.HasMany(I => I.Prices).WithOne(IP => IP.Item);
            builder.HasOne(I => I.Category).WithMany(c => c.Items).HasForeignKey(I => I.CategoryId);
        }

        public void Configure(EntityTypeBuilder<UserApp> builder)
        {
            builder.HasMany(u => u.AuditLogs).WithOne(al => al.Admin).HasForeignKey(al => al.AdminId);
        }
    }

}
