using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialApp.Core.Entities
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(Account))]
        public long AccountId { get; set; }

        public Account Account { get; set; }

        public double Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
