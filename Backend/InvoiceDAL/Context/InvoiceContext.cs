using InvoiceDAL.Models;
using InvoiceDAL.Models.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDAL.Context
{
    public class InvoiceContext : IdentityDbContext<UserApp>
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Price> Prices { get; set; }
        public InvoiceContext(DbContextOptions<InvoiceContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemsRelationships).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
