using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Models.Configurations
{
    internal class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.AdminId);
            builder.Property(x => x.Timestamp).IsRequired();
            builder.Property(x => x.Action).IsRequired();
            builder.Property(x => x.AdminId).IsRequired();
            builder.Property(x => x.Entity).IsRequired();
            builder.Property(x => x.Data).IsRequired();
        }
    }
}
