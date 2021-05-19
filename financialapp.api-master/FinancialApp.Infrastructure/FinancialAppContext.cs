using System;
using FinancialApp.Core.Entities;
using FinancialApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp.Data
{
    public class FinancialAppContext : DbContext
    {
        public FinancialAppContext(DbContextOptions options)
            : base(options)
        {
            
        }
        public DbSet<Account> Account { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new TransactionConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
