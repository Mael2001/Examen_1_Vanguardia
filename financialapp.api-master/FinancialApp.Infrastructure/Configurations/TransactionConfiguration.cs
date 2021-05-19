using System;
using System.Collections.Generic;
using System.Text;
using FinancialApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancialApp.Data.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasData(new List<Transaction>
            {
                new Transaction
                {
                    Id = -5,
                    Amount = 500,
                    AccountId = -1,
                    Description = "Salario",
                    TransactionDate = DateTime.Today.AddDays(-5)
                },
                new Transaction
                {
                    Id = -1,
                    Amount = -20,
                    AccountId = -1,
                    Description = "Comida Dennys",
                    TransactionDate = DateTime.Today.AddDays(-1)
                },
                new Transaction
                {
                    Id = -2,
                    Amount = 1500,
                    AccountId = -2,
                    Description = "Salario",
                    TransactionDate = DateTime.Today
                },
                new Transaction
                {
                    Id = -3,
                    Amount = -5,
                    AccountId = -1,
                    Description = "Corte de pelo",
                    TransactionDate = DateTime.Today.AddDays(-2)
                }
            });
        }
    }
}
