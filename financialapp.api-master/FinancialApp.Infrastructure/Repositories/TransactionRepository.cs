using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinancialApp.Core.Entities;
using FinancialApp.Data;
using FinancialApp.Data.Repositories;

namespace FinancialApp.Infrastructure.Repositories
{
    class TransactionRepository : BaseRepository<Transaction>
    {
        private readonly FinancialAppContext _financialAppContext;

        public TransactionRepository(FinancialAppContext financialAppContext) : base(financialAppContext)
        {
            _financialAppContext = financialAppContext;
        }

        public override IReadOnlyList<Transaction> Get()
        {
            return _financialAppContext.Transaction.ToList();
        }

        public override Transaction Get(long id)
        {
            return _financialAppContext.Transaction.FirstOrDefault(x => x.Id == id);
        }

        public override IReadOnlyList<Transaction> Filter(Func<Transaction, bool> predicate)
        {
            return _financialAppContext.Transaction.Where(predicate).ToList();
        }
    }
}
