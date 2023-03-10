using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using DDDCustomerUi.Server.Models.DDDCustomerDb;

namespace DDDCustomerUi.Server.Data
{
    public partial class DDDCustomerDbContext : DbContext
    {
        public DDDCustomerDbContext()
        {
        }

        public DDDCustomerDbContext(DbContextOptions<DDDCustomerDbContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.OnModelBuilding(builder);
        }

        public DbSet<DDDCustomerUi.Server.Models.DDDCustomerDb.Customer> Customers { get; set; }
    }
}