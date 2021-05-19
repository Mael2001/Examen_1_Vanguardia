using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApp.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasData(new List<Account>
            {
                new Account
                {
                    Id = -1,
                    Amount = 475,
                    Currency = "USD",
                    Name = "Cuenta en dolares 1",
                    ConversionRate = 1
                },
                new Account
                {
                    Id = -2,
                    Amount = 1500,
                    Currency = "EUR",
                    Name = "Cuenta en euros única",
                    ConversionRate = 1.18
                },
                new Account
                {
                    Id = -3,
                    Amount = 0,
                    Currency = "USD",
                    Name = "Cuenta en dolares 2",
                    ConversionRate = 1
                }
            });
        }
    }
}
