using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialApp.Core.Entities
{
    public class Account
    {
        public Account()
        {
            this.Transactions = new HashSet<Transaction>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public double ConversionRate { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
